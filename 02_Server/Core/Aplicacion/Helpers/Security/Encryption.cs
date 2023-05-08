using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Aplicacion.Helpers.Security
{
    public class Encryption
    {
        public string Encrypt(string message)
        {
            try
            {
                string key = "12345678";
                if (message == null || message.Length <= 0)
                    throw new ArgumentException("message to encript Empty");
                if (key == null || key.Length <= 0)
                    throw new ArgumentException("key to encript Empty");

                byte[] encrypted;

                using (Aes aes = Aes.Create())
                {
                    var _key = UTF8Encoding.UTF8.GetBytes(key);
                    _key = SHA256.Create().ComputeHash(_key);
                    aes.Key = _key;
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform encrytor = aes.CreateEncryptor();
                    using MemoryStream msEncrypt = new();
                    using CryptoStream csEncrypt = new(msEncrypt, encrytor, CryptoStreamMode.Write);
                    using StreamWriter swEncrypt = new(csEncrypt);
                    swEncrypt.Write(message);
                    encrypted = msEncrypt.ToArray();
                }

                return Convert.ToBase64String(encrypted);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public string Decrypt(string message)
        {
            try
            {
                string key = "12345678";
                if (message == null || message.Length <= 0)
                    throw new ArgumentException("message to encript Empty");
                if (key == null || key.Length <= 0)
                    throw new ArgumentException("key to encript Empty");

                string result = string.Empty;
                
                using (Aes aes= Aes.Create())
                {
                    var _key = UTF8Encoding.UTF8.GetBytes(key);
                    _key = SHA256.Create().ComputeHash(_key);
                    aes.Key = _key;
                    aes.Mode = CipherMode.ECB;
                    aes.Padding = PaddingMode.PKCS7;
                    ICryptoTransform decrypt = aes.CreateDecryptor();
                    using MemoryStream msDecrypt = new(Convert.FromBase64String(message));
                    using CryptoStream csDecrypt = new(msDecrypt, decrypt, CryptoStreamMode.Read);
                    using StreamReader srDecrypt = new(csDecrypt);
                    result = srDecrypt.ReadToEnd();
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
