using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Crypto;

public partial class QR : System.Web.UI.Page
{
    //string publicKey = "<RSAKeyValue><Modulus>sDW7Ll/LHrp5lJWt9LjIfpfDX1ppojTelErotud4sAafaMg0pA4t0eSvE2+XTu83+tgHKDDUfc483DkGxfEoR1AJNs9utiHiKcRIN/YBk8suxQNJvpUg6oYrqtf5EYkC8+DzfbzAo7BCk7aGkElyNfefDu6oGSbiDZ4KE6RE+CU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
    //string privateKey = "<RSAKeyValue><Modulus>sDW7Ll/LHrp5lJWt9LjIfpfDX1ppojTelErotud4sAafaMg0pA4t0eSvE2+XTu83+tgHKDDUfc483DkGxfEoR1AJNs9utiHiKcRIN/YBk8suxQNJvpUg6oYrqtf5EYkC8+DzfbzAo7BCk7aGkElyNfefDu6oGSbiDZ4KE6RE+CU=</Modulus><Exponent>AQAB</Exponent><P>4WDbnOXpNiyzFcOOx0qpMftfeYS1xAxarINJMXbepvbVKlvhZqJrbw/6TMLXAQhWxokTt1cH3SCKs/szwWc/9w==</P><Q>yCawUnlmATg4orOjs2FF6zHxTTv06FsCv14TpyvkYdzSzzPpNVFULXyUFiraQ+ehH3oUW9BKEXCQdq5CO9j5ww==</Q><DP>SwxUtM8+NCL4U1P2NFihNJqO9UkCudCfVPi2o7kAdTqWSu+jg+iru6TnZS4wKBDdzGiS3yck4DZY2YvZdRpriw==</DP><DQ>My3hbFVqhelQYho5Q8cdz9RHdY5dQ4TyIOj3cYnBrlx+80i820tekPsICtsOUMrL4nae+hM6vVbhOde5TABhbQ==</DQ><InverseQ>cNSU9f4ifrUKMRih3G8ZDwQSfjj9b9zNZuwWRDq4rAOTOac+2gb36yGAu4lzMkRm+kIH4KONJXhhkTx2bno1qg==</InverseQ><D>jEBIGxIt9uhPix9T1TwagQBEhinNeEkCfB/feG1mlxy+VsU7ePS8LZsKarrgQPiQovy9PZUYHIZB1LsjE/vtpPpxrNMoDy9GvlLjbKyNL0U8bQsdxBXxUkkBqXE5fcPzYUPsDBBoZIT31OeD/sZ07/hOEYLWzjqZ21BQL0tXsEU=</D></RSAKeyValue>";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    //public byte[] ImageToByte(var img)
    //{
    //    ImageConverter converter = new ImageConverter();
    //    return (byte[])converter.ConvertTo(img, typeof(byte[]));
    //}

    protected void Button1_Click(object sender, EventArgs e)
    {
        //txtArt.Text = "49/02/657/17";
        //txtLabNum.Text = "1011805939";
        //txtArtSiteCode.Text = "159";

        //ARTNumber:49/02/657/17#LabNumber:1011805939#FacilityARTCode:159#
        
        QrCodeEncodingOptions options = new QrCodeEncodingOptions();
        options = new QrCodeEncodingOptions
        {
            DisableECI = true,
            CharacterSet = "UTF-8",
            Width = 250,
            Height = 250,
        };
        var writer = new BarcodeWriter();
        writer.Format = BarcodeFormat.QR_CODE;
        writer.Options = options;

        if (String.IsNullOrWhiteSpace(txtArt.Text) || String.IsNullOrEmpty(txtArt.Text))
        {
            Image1.ImageUrl = null;
            //MessageBox.Show("Text not found", "Oops!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            string str = string.Format("ARTNumber:{0}#LabNumber:{1}#FacilityARTCode:{2}",
                txtArt.Text.Trim(), txtLabNum.Text.Trim(), txtArtSiteCode.Text.Trim());

            //Ssymmetric encrypt
            //str = EncryptText(Encoding.UTF8.GetBytes(Encoding.UTF8.GetBytes(publicKey), str).ToString();
            //str = Crypto.RSA.Encrypt(str, publicKey, publicKey.Length);

            //Symmetric
            SymmetricAlgorithm aes = new AesManaged();
            //aes.Key = System.Text.Encoding.ASCII.GetBytes("LHrp5lJWt9LjIfpfDX1ppojT8lA4t0eS");            
            aes.Key = System.Text.Encoding.ASCII.GetBytes("4WDbnOXpNiyzFcOOx0qpMftfeYS1xAxa");
            //str = EncryptText(aes, str).ToString();

            //string decryptedText = DecryptData(aes, Encoding.ASCII.GetBytes(str));

            var qr = new ZXing.BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            var result = new Bitmap(qr.Write(str));            

            ImageConverter converter = new ImageConverter();
            byte[] arr = (byte[])converter.ConvertTo(result, typeof(byte[]));
            Image1.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(arr);
            //Image = (Image)result;
            //txtArt.Text = txtLabNum.Text = txtArtSiteCode.Text = string.Empty;            
        }

        #region Symmetric
        //// Create a new instance of the AES algorithm   
        //SymmetricAlgorithm aes = new AesManaged();

        //byte[] key = aes.Key; // Key propery contains the key of the aes algorithm you can create your own

        //Console.WriteLine("Enter your message here to encrypt:");
        //string message = Console.ReadLine();

        //// Call the encryptText method to encrypt the a string and save the result to a file   
        //EncryptText(aes, message, "encryptedData.dat");

        //// Call the decryptData method to get the encrypted text from the file and print it   
        ////Console.WriteLine("Decrypted message: {0}", DecryptData(aes, "encryptedData.dat"));
        //#endregion

        //#region Asymmetric
        //RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        //// Get the public keyy   
        //string publicKey = rsa.ToXmlString(false); // false to get the public key   
        //string privateKey = rsa.ToXmlString(true); // true to get the private key   

        //// Call the encryptText method   
        //EncryptText(publicKey, "Hello from C# Corner", "encryptedData.dat");

        // Call the decryptData method and print the result on the screen   
        //Console.WriteLine("Decrypted message: {0}", DecryptData(privateKey, "encryptedData.dat"));
        #endregion

        #region Asymmetric
        // Create an instance of the RSA algorithm class  
        RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
        // Get the public key
        //string publicKey = rsa.ToXmlString(false); // false to get the public key   
        //string privateKey = rsa.ToXmlString(true); // true to get the private key        

        //string publicKey = "<RSAKeyValue><Modulus>sDW7Ll/LHrp5lJWt9LjIfpfDX1ppojTelErotud4sAafaMg0pA4t0eSvE2+XTu83+tgHKDDUfc483DkGxfEoR1AJNs9utiHiKcRIN/YBk8suxQNJvpUg6oYrqtf5EYkC8+DzfbzAo7BCk7aGkElyNfefDu6oGSbiDZ4KE6RE+CU=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
        //string privateKey = "<RSAKeyValue><Modulus>sDW7Ll/LHrp5lJWt9LjIfpfDX1ppojTelErotud4sAafaMg0pA4t0eSvE2+XTu83+tgHKDDUfc483DkGxfEoR1AJNs9utiHiKcRIN/YBk8suxQNJvpUg6oYrqtf5EYkC8+DzfbzAo7BCk7aGkElyNfefDu6oGSbiDZ4KE6RE+CU=</Modulus><Exponent>AQAB</Exponent><P>4WDbnOXpNiyzFcOOx0qpMftfeYS1xAxarINJMXbepvbVKlvhZqJrbw/6TMLXAQhWxokTt1cH3SCKs/szwWc/9w==</P><Q>yCawUnlmATg4orOjs2FF6zHxTTv06FsCv14TpyvkYdzSzzPpNVFULXyUFiraQ+ehH3oUW9BKEXCQdq5CO9j5ww==</Q><DP>SwxUtM8+NCL4U1P2NFihNJqO9UkCudCfVPi2o7kAdTqWSu+jg+iru6TnZS4wKBDdzGiS3yck4DZY2YvZdRpriw==</DP><DQ>My3hbFVqhelQYho5Q8cdz9RHdY5dQ4TyIOj3cYnBrlx+80i820tekPsICtsOUMrL4nae+hM6vVbhOde5TABhbQ==</DQ><InverseQ>cNSU9f4ifrUKMRih3G8ZDwQSfjj9b9zNZuwWRDq4rAOTOac+2gb36yGAu4lzMkRm+kIH4KONJXhhkTx2bno1qg==</InverseQ><D>jEBIGxIt9uhPix9T1TwagQBEhinNeEkCfB/feG1mlxy+VsU7ePS8LZsKarrgQPiQovy9PZUYHIZB1LsjE/vtpPpxrNMoDy9GvlLjbKyNL0U8bQsdxBXxUkkBqXE5fcPzYUPsDBBoZIT31OeD/sZ07/hOEYLWzjqZ21BQL0tXsEU=</D></RSAKeyValue>";

        // Call the encryptText method   
        //byte[] encryptedData = EncryptText(publicKey, "Hello from C# Corner");
        //string decryptedData = DecryptData(privateKey, encryptedData);

        // Call the decryptData method and print the result on the screen   
        //Console.WriteLine("Decrypted message: {0}", DecryptData(privateKey, "encryptedData.dat"));
        #endregion
    }    

    //public static HtmlString GenerateQrCode(this HtmlHelper html, string url, string alt = "QR code", int height = 500, int width = 500, int margin = 0)
    //{
    //    var qrWriter = new ZXing.BarcodeWriterSvg();
    //    qrWriter.Format = ZXing.BarcodeFormat.QR_CODE;
    //    qrWriter.Options = new QrCodeEncodingOptions() { Height = height, Width = width, Margin = margin };

    //    using (var q = qrWriter.Write(url)) // Error 1 : rendering issues svgbarcode
    //    {
    //        using (var ms = new MemoryStream())
    //        {
    //            q.Save(ms, ImageFormat.Png);// Error 2 : save doesn't exist
    //            var img = new TagBuilder("img");
    //            img.Attributes.Add("src", String.Format("data:image/png;base64,{0}", Convert.ToBase64String(ms.ToArray())));
    //            img.Attributes.Add("alt", alt);

    //            return new HtmlString(img.ToString(TagRenderMode.SelfClosing)); // Error 3 : tostring overload
    //        }
    //    }
    //}

    #region Asymmetric - RSA
    //static byte[] EncryptText(string publicKey, string text)
    //{
    //    // Convert the text to an array of bytes   
    //    UnicodeEncoding byteConverter = new UnicodeEncoding();
    //    byte[] dataToEncrypt = byteConverter.GetBytes(text);

    //    // Create a byte array to store the encrypted data in it   
    //    byte[] encryptedData;
    //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    //    {
    //        // Set the rsa pulic key   
    //        rsa.FromXmlString(publicKey);

    //        // Encrypt the data and store it in the encyptedData Array   
    //        encryptedData = rsa.Encrypt(dataToEncrypt, false);
    //    }
    //    // Save the encypted data array into a file   
    //    //File.WriteAllBytes(fileName, encryptedData);

    //    //Console.WriteLine("Data has been encrypted");
    //    return encryptedData;
    //}

    // Method to decrypt the data withing a specific file using a RSA algorithm private key   
    //static string DecryptData(string privateKey, byte[] dataToDecrypt)
    //{
    //    // read the encrypted bytes from the file   
    //    //byte[] dataToDecrypt = File.ReadAllBytes(fileName);

    //    // Create an array to store the decrypted data in it   
    //    byte[] decryptedData;
    //    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    //    {
    //        // Set the private key of the algorithm   
    //        rsa.FromXmlString(privateKey);
    //        decryptedData = rsa.Decrypt(dataToDecrypt, false);
    //    }

    //    // Get the string value from the decryptedData byte array   
    //    UnicodeEncoding byteConverter = new UnicodeEncoding();
    //    return byteConverter.GetString(decryptedData);
    //}

    #endregion

    #region Symmetric - AES
    static byte[] EncryptText(SymmetricAlgorithm aesAlgorithm, string text)
    {
        // Create an encryptor from the AES algorithm instance and pass the aes algorithm key and inialiaztion vector to generate a new random sequence each time for the same text  
        ICryptoTransform encryptor = aesAlgorithm.CreateEncryptor(aesAlgorithm.Key, aesAlgorithm.IV);

        // Create a memory stream to save the encrypted data in it  
        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter writer = new StreamWriter(cs))
                {
                    // Write the text in the stream writer   
                    writer.Write(text);
                }
            }

            // Get the result as a byte array from the memory stream   
            byte[] encryptedDataBuffer = ms.ToArray();

            // Write the data to a file   
            //File.WriteAllBytes(fileName, encryptedDataBuffer);
            return encryptedDataBuffer;
        }
    }

    //Method to decrypt a data from a specific file and return the result as a string
    static string DecryptData(SymmetricAlgorithm aesAlgorithm, byte[] encryptedDataBuffer)
    {
        // Create a decryptor from the aes algorithm   
        ICryptoTransform decryptor = aesAlgorithm.CreateDecryptor(aesAlgorithm.Key, aesAlgorithm.IV);

        // Read the encrypted bytes from the file   
        //byte[] encryptedDataBuffer = File.ReadAllBytes(fileName);

        // Create a memorystream to write the decrypted data in it   
        using (MemoryStream ms = new MemoryStream(encryptedDataBuffer))
        {
            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
            {
                using (StreamReader reader = new StreamReader(cs))
                {
                    // Reutrn all the data from the streamreader   
                    return reader.ReadToEnd();
                }
            }
        }
    }
    #endregion
}