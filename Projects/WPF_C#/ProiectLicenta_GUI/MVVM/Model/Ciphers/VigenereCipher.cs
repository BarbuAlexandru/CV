using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model.Ciphers
{
    /// <summary>
    /// The class for the Vigenere cipher
    /// </summary>
    public class VigenereCipher
    {
        //the constructor
        public VigenereCipher()
        {

        }

        //The encrypting and decrypting functions
        public static string EncryptText(string txt, string key)
        {
            string encryptedText = string.Empty;

            int keyIterator = 0;
            for(int i=0; i<txt.Length; i++)
            {
                char actualKey = key[keyIterator % key.Length];
                if (CipherGeneralFunctions.CheckLetter(actualKey) == 1)
                {
                    actualKey -= 'A';
                }
                else if (CipherGeneralFunctions.CheckLetter(actualKey) == 0)
                {
                    actualKey -= 'a';
                }
                //if the character is not a letter, dont increment the key iterator.
                if (CipherGeneralFunctions.CheckLetter(txt[i]) != -1)
                {
                    keyIterator += 1;
                }
                encryptedText += CaesarCipher.EncryptCh(txt[i],actualKey);
            }

            return encryptedText;
        }

        public static string DecryptText(string txt, string key)
        {
            string decryptedText = string.Empty;

            int keyIterator = 0;
            for (int i = 0; i < txt.Length; i++)
            {
                char actualKey = key[keyIterator % key.Length];
                if (CipherGeneralFunctions.CheckLetter(actualKey) == 1)
                {
                    actualKey -= 'A';
                }
                else if (CipherGeneralFunctions.CheckLetter(actualKey) == 0)
                {
                    actualKey -= 'a';
                }
                //if the character is not a letter, dont increment the key iterator.
                if (CipherGeneralFunctions.CheckLetter(txt[i]) != -1)
                {
                    keyIterator += 1;
                }
                decryptedText += CaesarCipher.DecryptCh(txt[i], actualKey);
            }

            return decryptedText;
        }
    }
}
