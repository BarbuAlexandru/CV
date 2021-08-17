using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model.Ciphers
{
    /// <summary>
    /// The Class for the Caesar cipher.
    /// </summary>
    public class CaesarCipher
    {
        //the function the encrypt only 1 char at a time
        public static char EncryptCh(char letter, int key)
        {
            char encryptedLetter = letter;
            if (CipherGeneralFunctions.CheckLetter(encryptedLetter) == 1)
            {
                for (int i = 0; i < key; i++)
                {
                    if (encryptedLetter + 1 <= 'Z')
                    {
                        encryptedLetter = (char)(encryptedLetter + 1);
                    }
                    else
                    {
                        encryptedLetter = 'A';
                    }
                }
            }
            else if (CipherGeneralFunctions.CheckLetter(encryptedLetter) == 0)
            {
                for (int i = 0; i < key; i++)
                {
                    if (encryptedLetter + 1 <= 'z')
                    {
                        encryptedLetter = (char)(encryptedLetter + 1);
                    }
                    else
                    {
                        encryptedLetter = 'a';
                    }
                }
            }
            return encryptedLetter;
        }


        //the function the decrypt only 1 char at a time
        public static char DecryptCh(char letter, int key)
        {
            char decryptedLetter = letter;
            if (CipherGeneralFunctions.CheckLetter(decryptedLetter) == 1)
            {
                for (int i = 0; i < key; i++)
                {
                    if (decryptedLetter - 1 >= 'A')
                    {
                        decryptedLetter = (char)(decryptedLetter - 1);
                    }
                    else
                    {
                        decryptedLetter = 'Z';
                    }
                }
            }
            else if (CipherGeneralFunctions.CheckLetter(decryptedLetter) == 0)
            {
                for (int i = 0; i < key; i++)
                {
                    if (decryptedLetter - 1 >= 'a')
                    {
                        decryptedLetter = (char)(decryptedLetter - 1);
                    }
                    else
                    {
                        decryptedLetter = 'z';
                    }
                }
            }
            return decryptedLetter;
        }

        //the constructor
        public CaesarCipher()
        {

        }

        //The encryption and decryption functions
        public static string EncryptText(string txt, string key)
        {
            //prepare the text and the key
            string encryptedTxt = string.Empty;
            char actualKey = key[0];
            if (CipherGeneralFunctions.CheckLetter(actualKey)==1)
            {
                actualKey -= 'A';
            }
            else if (CipherGeneralFunctions.CheckLetter(actualKey) == 0)
            {
                actualKey -= 'a';
            }
            //actually encrypt the text
            for(int i=0; i<txt.Length; i++)
            {
                encryptedTxt += EncryptCh(txt[i], actualKey);
            }
            return encryptedTxt;
        }

        public static string DecryptText(string txt, string key)
        {
            //prepare the text and the key
            string decryptedText = string.Empty;
            char actualKey = key[0];
            if (CipherGeneralFunctions.CheckLetter(actualKey) == 1)
            {
                actualKey -= 'A';
            }
            else if (CipherGeneralFunctions.CheckLetter(actualKey) == 0)
            {
                actualKey -= 'a';
            }
            //actually encrypt the text
            for (int i = 0; i < txt.Length; i++)
            {
                decryptedText += DecryptCh(txt[i], actualKey);
            }
            return decryptedText;
        }
    }
}
