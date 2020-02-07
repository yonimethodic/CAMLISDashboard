using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Crypto
/// </summary>
// <summary>
// 1. From http://www.csharpdeveloping.net/Snippet/how_to_encrypt_decrypt_using_asymmetric_algorithm_rsa
// An asymmetric algorithm to publically encrypt and privately decrypt text data.
// </summary>

namespace Crypto
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class RSA
    {
        /// <summary>
        /// The padding scheme often used together with RSA encryption.
        /// </summary>
        private static bool _optimalAsymmetricEncryptionPadding = false;

        public static string publicKey = "<RSAKeyValue>" +
                    "<Modulus>350txEjR1LZ2XgqcO5kqFjuZN7IKzER9PdE3x2vVZHCYu9SEKqURyjIHSiZ9FKOw40cHMSzRmyYnwShzDJ+K7s+5pJ5AIl+QZh5LyA3SLkRkGc9crAZzY5y/SPz8RbRNT0W3A8JB1Ur3BF3bhRXbvJccBog9Wa6TfBy23tOaMb0</Modulus>" +
                    "<Exponent>AQAB</Exponent>" +
                    "</RSAKeyValue>";

        public static string publicAndPrivateKey = "<RSAKeyValue>" +
                    "<Modulus>350txEjR1LZ2XgqcO5kqFjuZN7IKzER9PdE3x2vVZHCYu9SEKqURyjIHSiZ9FKOw40cHMSzRmyYnwShzDJ+K7s+5pJ5AIl+QZh5LyA3SLkRkGc9crAZzY5y/SPz8RbRNT0W3A8JB1Ur3BF3bhRXbvJccBog9Wa6TfBy23tOaMb0</Modulus>" +
                    "<Exponent>AQAB</Exponent>" +
                    "<P>4AVv5x3Cd7VCNIQ/mOqMoPjn+tpX+p8S4UC6YvFfIkGIFDk8VTF+2Jq2DZUvJSDdw8qSZ0OXApYav4XXBCAgzw</P>" +
                    "<Q>/4jb4Ra6BJQKx1VzTK5w/z7kDfjLEFKy6tp+YH3dTWpwiQkb4zpWeCyljhj3d0DPRVjHBiS8dKozrEhhUd7vsw</Q>" +
                    "<DP>PS3+85VTCLI91G3RmIdlxIh1gjKjGFTdKRsuS9szaf2PlkZTTcjopWsLEQaPC4rARbpK5Vy2HwSzZV696+iCTQ</DP>" +
                    "<DQ>r3x+fCsOXnyIlnIBd6TIpxG6rjmwwqn4gz6/0WY+p560X/eodjknDuqiW16b/AK/FUGtlHOAFKKaT/N5Gi9+7w</DQ>" +
                    "<InverseQ>O6apXuDYNN96hKzy8lAoP+Nin/IcjZFfWXISJJuB+2rjVzrTCznNOuY2wJbiBkUlnXuE2PwnWJkgK5INz7SLmg</InverseQ>" +
                    "<D>m08B0Ih7JHAuOhbIeCRjNNnkCujf0wvmqJ69TQa6SW5ixmJOAYhwmKyyn2+oBEPEwbY9aowkcMvJZMEBV00gInyUvri7klYOtYhVEBjFz+DW3JX+RGPanI+iw5oVONCv9g4+Kj4rogRUQbPL6wgYHOGQTDqMpiqa3Os4SxqGOkk</D>" +
                    "</RSAKeyValue>";

        //public static void GenerateKeys(int keySize, out string publicKey, out string publicAndPrivateKey)
        //{
        //    using (var provider = new RSACryptoServiceProvider(keySize))
        //    {
        //        publicKey = provider.ToXmlString(false);
        //        publicAndPrivateKey = provider.ToXmlString(true);                
        //    }
        //}

        /// <summary>
        /// Converts the RSA-encrypted text into a string
        /// </summary>
        /// <param name="text">The plain text input</param>
        /// <param name="publicKeyXml">The RSA public key in XML format</param>
        /// <param name="keySize">The RSA key length</param>
        /// <returns>The the RSA-encrypted text</returns>
        public static string Encrypt(string text, string publicKeyXml, int keySize)
        {
            var encrypted = EncryptByteArray(Encoding.UTF8.GetBytes(text), publicKeyXml, keySize);

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// Gets and validates the RSA-encrypted text as a byte array
        /// </summary>
        /// <param name="data">The plain text in byte array format</param>
        /// <param name="publicKeyXml">The RSA public key in XML format</param>
        /// <param name="keySize">The RSA key length</param>
        /// <returns>The the RSA-encrypted byte array</returns>
        private static byte[] EncryptByteArray(byte[] data, string publicKeyXml, int keySize)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data are empty", "data");
            }

            int maxLength = GetMaxDataLength(keySize);

            if (data.Length > maxLength)
            {
                throw new ArgumentException(String.Format("Maximum data length is {0}", maxLength), "data");
            }

            if (!IsKeySizeValid(keySize))
            {
                throw new ArgumentException("Key size is not valid", "keySize");
            }

            if (String.IsNullOrEmpty(publicKeyXml))
            {
                throw new ArgumentException("Key is null or empty", "publicKeyXml");
            }

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                provider.FromXmlString(publicKeyXml);
                return provider.Encrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        /// <summary>
        /// Converts the RSA-decrypted text into a string
        /// </summary>
        /// <param name="text">The plain text input</param>
        /// <param name="publicKeyXml">The RSA public key in XML format</param>
        /// <param name="keySize">The RSA key length</param>
        /// <returns>The the RSA-decrypted text</returns>
        public static string Decrypt(string text, string publicAndPrivateKeyXml, int keySize)
        {
            var decrypted = DecryptByteArray(Convert.FromBase64String(text), publicAndPrivateKeyXml, keySize);
            return Encoding.UTF8.GetString(decrypted);
        }

        /// <summary>
        /// Gets and validates the RSA-decrypted text as a byte array
        /// </summary>
        /// <param name="data">The plain text in byte array format</param>
        /// <param name="publicKeyXml">The RSA public key in XML format</param>
        /// <param name="keySize">The RSA key length</param>
        /// <returns>The the RSA-decrypted byte array</returns>
        private static byte[] DecryptByteArray(byte[] data, string publicAndPrivateKeyXml, int keySize)
        {
            if (data == null || data.Length == 0)
            {
                throw new ArgumentException("Data are empty", "data");
            }

            if (!IsKeySizeValid(keySize))
            {
                throw new ArgumentException("Key size is not valid", "keySize");
            }

            if (String.IsNullOrEmpty(publicAndPrivateKeyXml))
            {
                throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");
            }

            using (var provider = new RSACryptoServiceProvider(keySize))
            {
                provider.FromXmlString(publicAndPrivateKeyXml);
                return provider.Decrypt(data, _optimalAsymmetricEncryptionPadding);
            }
        }

        /// <summary>
        /// Gets the maximum data length for a given key
        /// </summary>       
        /// <param name="keySize">The RSA key length</param>
        /// <returns>The maximum allowable data length</returns>
        public static int GetMaxDataLength(int keySize)
        {
            if (_optimalAsymmetricEncryptionPadding)
            {
                return ((keySize - 384) / 8) + 7;
            }
            return ((keySize - 384) / 8) + 37;
        }

        /// <summary>
        /// Checks if the given key size if valid
        /// </summary>       
        /// <param name="keySize">The RSA key length</param>
        /// <returns>True if valid; false otherwise</returns>
        public static bool IsKeySizeValid(int keySize)
        {
            return keySize >= 384 &&
                   keySize <= 16384 &&
                   keySize % 8 == 0;
        }
    }
}