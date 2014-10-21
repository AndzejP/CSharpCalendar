using System.Security.Cryptography;
using System.IO;

namespace Calendar
{
    class Event
    {
        static Rijndael myRijndael =  Rijndael.Create();

        public Date date;
        private byte[] _encrypted;

        public string Description
        {
            get
            {
                return DecryptStringFromBytes(_encrypted, myRijndael.Key, myRijndael.IV);
            }
            set
            {
                _encrypted = EncryptStringToBytes(value, myRijndael.Key, myRijndael.IV);
            }
        }
        public Event (Date date, string description)
        {
            this.date = date;
            Description = description;

        }
        

        static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            byte[] encryption;

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key,rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {

                            swEncrypt.Write(plainText);
                        }
                        encryption = msEncrypt.ToArray();
                    }
                }
            }

            return encryption;

        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            string plaintext;

            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);
 
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;

        }


    }
}
