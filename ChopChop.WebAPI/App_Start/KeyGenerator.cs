using ChopChop.ViewModel;
using ChopChopApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace ChopChopApi.App_Start
{
    public static class KeyGenerator
    {
        public static string GetUniqueKey(int maxSize = 15)
        {
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static void GenerateUniqueKey(out string ClientID, out string ClientSecert)
        {
            ClientID = KeyGenerator.GetUniqueKey();
            ClientSecert = KeyGenerator.GetUniqueKey();
        }

        public static string GenerateToken(UserModel objUserModel)
        {
            try
            {
                string randomnumber =
                   string.Join(":", new string[]
                   {   Convert.ToString(objUserModel.UserID),
                KeyGenerator.GetUniqueKey(),
                Convert.ToString(objUserModel.UserName),
                KeyGenerator.GetUniqueKey(),
                //,
                //Convert.ToString(ClientKeys.CompanyID),
                //Convert.ToString(IssuedOn.Ticks),
                //ClientKeys.ClientID
                   });

                return EncryptionLibrary.EncryptText(randomnumber);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string generateOTP()
        {
            int lenthofpass = 6;
            string allowedChars = "";
            allowedChars += "1,2,3,4,5,6,7,8,9,0";
            char[] sep =   {  
                                ','  
                            };
            string[] arr = allowedChars.Split(sep);
            string passwordString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < lenthofpass; i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                passwordString += temp;
            }
            return passwordString;
        }
    }
}