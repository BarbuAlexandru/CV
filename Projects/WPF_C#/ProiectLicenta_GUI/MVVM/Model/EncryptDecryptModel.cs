using ProiectLicenta_GUI.MVVM.Model.Ciphers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model
{
    /// <summary>
    /// The model that manages the encryption and decryption of text
    /// </summary>
    public class EncryptDecryptModel
    {
        public EncryptDecryptModel()
        {
            
        }


        //The encrypt text function
        public static string EncryptText(string txt, string key, string cipher)
        {
            //Check for each cipher and when it is the right one encrypt it
            if (cipher.Contains("Caesar"))
            {
                return CaesarCipher.EncryptText(txt, key);
            }
            if (cipher.Contains("Vigenere"))
            {
                return VigenereCipher.EncryptText(txt, key);
            }
            if (cipher.Contains("Beaufort"))
            {
                return BeaufortCipher.BeaufortEncryptDecrypt(txt, key);
            }
            if (cipher.Contains("Autokey"))
            {
                return AutokeyCipher.EncryptText(txt, key);
            }
            if (cipher.Contains("Playfair"))
            {
                return PlayfairCipher.EncryptText(txt, key);
            }

            return "ERROR - the cipher selected was not found.";
        }

        //The decrypt text function
        public static string DecryptText(string txt, string key, string cipher)
        {
            //Check for each cipher and when it is the right one decrypt it
            if (cipher.Contains("Caesar"))
            {
                return CaesarCipher.DecryptText(txt, key);
            }
            if (cipher.Contains("Vigenere"))
            {
                return VigenereCipher.DecryptText(txt, key);
            }
            if (cipher.Contains("Beaufort"))
            {
                return BeaufortCipher.BeaufortEncryptDecrypt(txt, key);
            }
            if (cipher.Contains("Autokey"))
            {
                return AutokeyCipher.DecryptText(txt, key);
            }
            if (cipher.Contains("Playfair"))
            {
                return PlayfairCipher.DecryptText(txt, key);
            }

            return "ERROR - the cipher selected was not found.";
        }
    }
}
