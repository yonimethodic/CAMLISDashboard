using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CHAI.LISDashboard.Shared.Settings
{
    /// <summary>
    /// Technical parameters.
    /// </summary
    public static class TechnicalSettings
    {
        private const string VERSION   = "1.0.0.*";
        private const string COMPANY   = "SKDH Ethiopia";
        private const string PRODUCT   = "Building";
        private const string COPYRIGHT = "SKDH 2012";

        public static string SoftwareVersion
        {
            get { return string.Format("v{0}", VERSION); }
        }

        public static string Copyright
        {
            get { return COPYRIGHT; }
        }

        public static string Product
        {
            get { return PRODUCT; }
        }

        public static string Company
        {
            get { return COMPANY; }
        }

        public static string ConnectionString
        {
            //get { return TechnicalConfig.GetConfiguration()["ConnectionString"]; }

            //updated by ZaySoe on 24-Jun-2019
            //<add setting="ConnectionString" value="Data Source=.\sqlexpress;Initial Catalog=LISDashboard;User id=webuser;Password=password;MultipleActiveResultSets=True" />

            //<add setting="ConnectionString" value="Data Source=.\sqlexpress;Initial Catalog=LISDashboard;User ID=ruser;Password=xD7%g2tkRDN@2gg^;MultipleActiveResultSets=True"/>            
            //<add setting="ConnectionString" value="Data Source=WIN-ERAM9TL54U4;Initial Catalog=LISDashboard;User id=ruser;Password=xD7%g2tkRDN@2gg^;MultipleActiveResultSets=True" />
           // get { return Decrypt(TechnicalConfig.GetConfiguration()["ConnectionString"]); }
            get { return TechnicalConfig.GetConfiguration()["ConnectionString"]; }
        }

        public static string Decrypt(string cipherText)
        {
            //Q0hBSU9wZW5NUlMrTElNUw==
            //string key = TechnicalConfig.GetConfiguration()["QRINPUTKEY"].ToString();
            /*
            string key = "Q0hBSU9wZW5NUlMrTElNUw==";

            RijndaelManaged aes = new RijndaelManaged();
            aes.BlockSize = 128;
            aes.KeySize = 256;

            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            byte[] keyArr = Convert.FromBase64String(key);
            byte[] KeyArrBytes32Value = new byte[16];
            Array.Copy(keyArr, KeyArrBytes32Value, 16);

            // It must be same as in Java
            byte[] ivArr = { 1, 2, 3, 4, 5, 6, 6, 5, 4, 3, 2, 1, 7, 7, 7, 7 };
            byte[] IVBytes16Value = new byte[16];
            Array.Copy(ivArr, IVBytes16Value, 16);

            aes.Key = KeyArrBytes32Value;
            aes.IV = IVBytes16Value;

            ICryptoTransform decrypto = aes.CreateDecryptor();

            byte[] encryptedBytes = Convert.FromBase64CharArray(cipherText.ToCharArray(), 0, cipherText.Length);
            byte[] decryptedData = decrypto.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
            return Encoding.UTF8.GetString(decryptedData);
            */
            return cipherText;
        }
    }

}
