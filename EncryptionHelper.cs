using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace PSR
{ 
    public static class EncryptionHelper
    {
        //private static readonly string SecretKey = "YourSecretKey123"; // Same as used in JavaScript

        public static string DecryptSSOID(string encryptedSSOID)
        {
            var key = Encoding.UTF8.GetBytes("1234567890123456"); // same 16 chars
            var iv = Encoding.UTF8.GetBytes("1234567890123456");  // same 16 chars

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                byte[] cipherText = Convert.FromBase64String(encryptedSSOID);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt, Encoding.UTF8))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }

}