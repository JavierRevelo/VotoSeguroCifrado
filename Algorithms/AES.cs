using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace VotoSeguroEncryp.Algorithms
{
    public class AES
    {
        // Clave secreta para el cifrado AES (debe tener 16, 24 o 32 bytes)
        private const string clave = "0123456789abcdef";

        // Método para cifrar un string utilizando AES
        public static string CifrarAES(string texto)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(clave);
                aesAlg.Mode = CipherMode.ECB; // Modo de cifrado ECB (Electronic Codebook)
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(texto);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
        }
    }
}
