using System;
using System.IO;
using System.Security.Cryptography;

namespace SaveSystem.CryptographicUtils
{
    public static class CryptoUtilities
    {
        private const int KEY_LENGTH = 32;
        private const int IV_LENGTH = 16;
        public static byte[] Encrypt(string plainText)
        {
            byte[] encryptedBytes;
            if (string.IsNullOrEmpty(plainText))
                throw new ArgumentNullException(nameof(plainText), "Text for encryption cannot be null");

            using (var aesAlg = Aes.Create())
            {
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                byte[] encryptedDataBytes;
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) 
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encryptedDataBytes = msEncrypt.ToArray();
                    }
                }

                var resultArray = new byte[KEY_LENGTH + IV_LENGTH + encryptedDataBytes.Length];
                aesAlg.Key.CopyTo(resultArray,0);
                encryptedDataBytes.CopyTo(resultArray, KEY_LENGTH);
                aesAlg.IV.CopyTo(resultArray, KEY_LENGTH + encryptedDataBytes.Length);
                
                encryptedBytes = resultArray;
            }
            
            return encryptedBytes;
        }

        public static string Decrypt(byte[] encrypted)
        {
            string decryptedString;
            var cipher = new byte[encrypted.Length - IV_LENGTH - KEY_LENGTH];
            var key = encrypted[..KEY_LENGTH];
            var iv = encrypted[^IV_LENGTH..];
            Array.Copy(encrypted, KEY_LENGTH, cipher, 0, cipher.Length);
            using (var aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = iv;
                
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            
                using (var msDecrypt = new MemoryStream(cipher))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            decryptedString = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            return decryptedString;
        }
    }
}