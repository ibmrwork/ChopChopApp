
using Elmah;

using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Web;


namespace ChopChop.Utility
{
    public class EmailHelper
    {
        /// <summary>
        /// Send an email
        /// </summary>
        /// <param name="to">Message to address</param>
        /// <param name="body">Text of message to send</param>
        /// <param name="subject">Subject line of message</param>
        /// <param name="fromAddress">Message from address</param>
        /// <param name="fromDisplay">Display name for "message from address"</param>
        /// <param name="credentialUser">User whose credentials are used for message send</param>
        /// <param name="credentialPassword">User password used for message send</param>
        /// <param name="attachments">Optional attachments for message</param>
        public static bool Email(string to,
                                 string body,
                                 string subject,
                                 string fromDisplay,
                                 params MailAttachment[] attachments)
        {
            string host = ConfigurationManager.AppSettings["SMTPHost"];
            string fromAddress = ConfigurationManager.AppSettings["fromMail"];
            string smtpUserName = ConfigurationManager.AppSettings["smtpUser"];
            string smtpPassword = ConfigurationManager.AppSettings["smtpPassword"];
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(fromAddress, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = System.Net.Mail.MailPriority.Normal;
                if (attachments != null && attachments.Length > 0)
                {
                    foreach (MailAttachment ma in attachments)
                    {
                        mail.Attachments.Add(ma.File);
                    }
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]);
                smtp.Host = host;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:" + to);
                sb.Append("\nbody:" + body);
                sb.Append("\nsubject:" + subject);
                sb.Append("\nfromAddress:" + fromAddress);
                sb.Append("\nfromDisplay:" + fromDisplay);
                sb.Append("\ncredentialUser:" + smtpUserName);
                sb.Append("\ncredentialPasswordto:" + smtpPassword);
                sb.Append("\nHosting:" + host);
                ErrorSignal.FromCurrentContext().Raise(ex);
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }

        public static bool SendEmail(string to,
                                string from,
                                string body,
                                string subject,
                                string fromDisplay,
                                params MailAttachment[] attachments)
        {
            string host = ConfigurationManager.AppSettings["SMTPHost"];           
            string smtpUserName = ConfigurationManager.AppSettings["smtpUser"];
            string smtpPassword = ConfigurationManager.AppSettings["smtpPassword"];
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(from, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = System.Net.Mail.MailPriority.Normal;
                if (attachments != null && attachments.Length > 0)
                {
                    foreach (MailAttachment ma in attachments)
                    {
                        mail.Attachments.Add(ma.File);
                    }
                }
                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new System.Net.NetworkCredential(smtpUserName, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]);
                smtp.Host = host;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                StringBuilder sb = new StringBuilder(1024);
                sb.Append("\nTo:" + to);
                sb.Append("\nbody:" + body);
                sb.Append("\nsubject:" + subject);
                sb.Append("\nfromAddress:" + from);
                sb.Append("\nfromDisplay:" + fromDisplay);
                sb.Append("\ncredentialUser:" + smtpUserName);
                sb.Append("\ncredentialPasswordto:" + smtpPassword);
                sb.Append("\nHosting:" + host);
                ErrorSignal.FromCurrentContext().Raise(ex);
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                return false;
            }
        }


        public static string EmailUserProfile(string name, string Email)
        {
            #region Declaration
            string bodyContent = string.Empty;
            #endregion Declaration

            try
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates/UserProfile.txt")))
                {
                    bodyContent = reader.ReadToEnd();
                    bodyContent = bodyContent.Replace("{username}", name);
                    bodyContent = bodyContent.Replace("{email}", Email);
                }

                return bodyContent;
            }
            catch (Exception ex)
            {
                ErrorSignal.FromCurrentContext().Raise(ex);
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                return string.Empty;
            }
        }

        public static string EmailBodyRegister(string name, string Email, string password, string verifylink, string activationcode)
        {
            #region Declaration
            string bodyContent = string.Empty;
            #endregion Declaration
            try
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates/UserRegistration.txt")))
                {
                    bodyContent = reader.ReadToEnd();
                    bodyContent = bodyContent.Replace("{username}", name);
                    bodyContent = bodyContent.Replace("{email}", Email);
                    bodyContent = bodyContent.Replace("{verifylink}", verifylink);
                    bodyContent = bodyContent.Replace("{userpassword}", password);
                    bodyContent = bodyContent.Replace("{useractivationcode}", activationcode);
                }
                return bodyContent;
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                ErrorSignal.FromCurrentContext().Raise(ex);
                return string.Empty;
            }
        }

        public static string EmailForgotPassword(string name, string Email, string password)
        {
            #region Declaration
            string bodyContent = string.Empty;
            #endregion Declaration
            try
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates/ForgotPassword.txt")))
                {
                    bodyContent = reader.ReadToEnd();
                    bodyContent = bodyContent.Replace("{username}", name);
                    bodyContent = bodyContent.Replace("{userpassword}", password);

                }
                return bodyContent;
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                ErrorSignal.FromCurrentContext().Raise(ex);
                return string.Empty;
            }
        }

        public static string EmailBodyApprovaUser(bool approvalStatus, string username)
        {
            #region Declaration
            string bodyContent = string.Empty;
            #endregion Declaration
            try
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates/UserApprove.txt")))
                {
                    bodyContent = reader.ReadToEnd();
                    bodyContent = bodyContent.Replace("{username}", username);
                    bodyContent = bodyContent.Replace("{approval}", approvalStatus == true ? "approved" : "rejected");
                }
                return bodyContent;
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                ErrorSignal.FromCurrentContext().Raise(ex);
                return string.Empty;
            }
        }

        public static string EmailBodySendProposal(string jobUserName, string Description, string orderID)
        {
            #region Declaration
            string bodyContent = string.Empty;
            #endregion Declaration
            try
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates/SupplierSubmitProposal.txt")))
                {
                    bodyContent = reader.ReadToEnd();
                    bodyContent = bodyContent.Replace("{jobusername}", jobUserName);
                    bodyContent = bodyContent.Replace("{orderid}", orderID);
                    bodyContent = bodyContent.Replace("{proposaldescription}", Description);
                }
                return bodyContent;
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                ErrorSignal.FromCurrentContext().Raise(ex);
                return string.Empty;
            }
        }

        public static string EmailBodySendProposalStatus(string jobUserName, string Description, string orderID, string status)
        {
            #region Declaration
            string bodyContent = string.Empty;
            #endregion Declaration
            try
            {
                using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/EmailTemplates/SupplierSubmitProposal.txt")))
                {
                    bodyContent = reader.ReadToEnd();
                    bodyContent = bodyContent.Replace("{username}", jobUserName);
                    bodyContent = bodyContent.Replace("{orderid}", orderID);
                    bodyContent = bodyContent.Replace("{proposaldescription}", Description);
                    bodyContent = bodyContent.Replace("{status}", status);
                }
                return bodyContent;
            }
            catch (Exception ex)
            {
                HelperClass.WriteLog(AppDomain.CurrentDomain.BaseDirectory + GlobalConstant.ErrorPath, ex.Message.ToString(), Convert.ToString(ex.InnerException, CultureInfo.CurrentCulture), Convert.ToString(ex.StackTrace, CultureInfo.CurrentCulture), MethodBase.GetCurrentMethod().DeclaringType.ToString(), MethodBase.GetCurrentMethod().Name);
                ErrorSignal.FromCurrentContext().Raise(ex);
                return string.Empty;
            }
        }
    }
}