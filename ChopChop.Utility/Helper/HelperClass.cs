using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ChopChop.Utility
{
    public static class HelperClass
    {
        public static string GeneratePassword(int length) //length of salt    
        {
            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            for (var i = 0; i <= length - 1; i++)
            {
                chars[i] = allowedChars[Convert.ToInt32((allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }
        public static string EncodePassword(string pass, string salt) //encrypt password    
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            //return Convert.ToBase64String(inArray);    
            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);
        }
        public static string base64Encode(string sData) // Encode    
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }
        public static string base64Decode(string sData) //Decode    
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Decode" + ex.Message);
            }
        }
        public static int nthOccurrence(String str, char c, int n)
        {
            int pos = str.IndexOf(c, 0);
            while (n-- > 0 && pos != -1)
                pos = str.IndexOf(c, pos + 1);
            return pos;
        }
        public static string Url()
        {
            string hostName = HttpContext.Current.Request.Url.ToString();
            int index = nthOccurrence(hostName, '/', 2);
            hostName = hostName.Substring(0, index);
            return hostName;
        }
        /// <summary>
        /// Function is used to write error in error log file
        /// </summary>
        /// <param name="logFile"></param>
        /// <param name="text"></param>       

        public static void WriteLog(string logFile, string messageValue, string innerException, string text, string controllerName, string parentView)
        {
            string CurrDate = "\\GTLogFile-" + DateTime.Now.ToString("MM-dd-yyyy");
            string logFileName = logFile + CurrDate + ".txt";
            string uID = Convert.ToString(HttpContext.Current.Session["LogedUserID"]);
            //string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Logs/ErrorLog_" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt";

            if (File.Exists(logFileName))
            {
                using (StreamWriter writer = new StreamWriter(logFileName, true))
                {
                    writer.WriteLine(Environment.NewLine);
                    writer.WriteLine(DateTime.Now.ToString());
                    writer.WriteLine("UserID: " + uID);
                    writer.WriteLine("Error On: " + controllerName);
                    writer.WriteLine("Funciton Name:" + parentView);
                    writer.WriteLine("Message:" + messageValue);
                    writer.WriteLine("Inner Exception:" + innerException);
                    writer.WriteLine("Stack Trace:" + text);
                    writer.WriteLine(text);
                    writer.WriteLine("======================================================================================================");

                }
            }
            else
            {
                StreamWriter writer = File.CreateText(logFileName);
                writer.WriteLine(Environment.NewLine);
                writer.WriteLine(DateTime.Now.ToString());
                writer.WriteLine("UserID: " + uID);
                writer.WriteLine("Error On: " + controllerName);
                writer.WriteLine("Funciton Name:" + parentView);
                writer.WriteLine("Message:" + messageValue);
                writer.WriteLine("Inner Exception:" + innerException);
                writer.WriteLine("Stack Trace:" + text);
                writer.WriteLine(text);
                writer.WriteLine("======================================================================================================");

                writer.Close();


            }
        }
        public static string GenerateRandomOTP(int iOTPLength)
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

        }
    }
}
