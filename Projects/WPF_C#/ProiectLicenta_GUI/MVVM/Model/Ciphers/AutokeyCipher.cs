using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model.Ciphers
{
    /// <summary>
    /// The class for the Autokey cipher
    /// </summary>
    public class AutokeyCipher
    {
        //The constructor
        public AutokeyCipher()
        {

        }

        public static int GetLetterNumber(char letter)
        {
            //returns the letter number in the alphabet
            if (CipherGeneralFunctions.CheckLetter(letter) == 1)
            {
                return letter - 'A';
            }
            else
            {
                return letter - 'a';
            }
        }

        public static char GetLetterFromNumber(int number, int letterCase)
        {
            //returns the letter from its number in the alphabet
            //letterCase is 1 for Uppercase and 0 for lowercase
            if (letterCase == 1)
            {
                return (char)('A' + number);
            }
            else
            {
                return (char)('a' + number);
            }
        }

        public static char EncryptLetter(char letter, char key)
        {
            //Encrypt the letter using the key
            int letterNumber = GetLetterNumber(letter);
            int newLetterNumber = letterNumber + GetLetterNumber(key);
            if (newLetterNumber > 25)
            {
                newLetterNumber -= 26;
            }
            return GetLetterFromNumber(newLetterNumber, CipherGeneralFunctions.CheckLetter(letter));
        }

        public static char DecryptLetter(char letter, char key)
        {
            //Decrypt the letter using the key
            int letterNumber = GetLetterNumber(letter);
            int newLetterNumber = letterNumber - GetLetterNumber(key);
            if (newLetterNumber < 0)
            {
                newLetterNumber += 26;
            }
            return GetLetterFromNumber(newLetterNumber, CipherGeneralFunctions.CheckLetter(letter));
        }

        public static string DecryptText(string input_text, string keyDefault)
        {
            string key = CipherGeneralFunctions.GetOnlyUpperLettersText(keyDefault);
            if (key.Length == 0) { key += 'A'; }
            string decryptedText = string.Empty;
            int currentPos = 0;
            int keyIterator = 0;
            for (int i = 0; i < input_text.Length; i++)
            {
                //check if the character is a letter
                if (CipherGeneralFunctions.CheckLetter(input_text[i]) != -1)
                {
                    if (currentPos < key.Length)
                    {
                        //decrypt the letter using the key letter
                        decryptedText += DecryptLetter(input_text[i], key[currentPos]);
                    }
                    else
                    {
                        //decrypt the letter using the letter previously decrypted
                        while (CipherGeneralFunctions.CheckLetter(decryptedText[keyIterator]) == -1)
                        {
                            keyIterator += 1;
                        }
                        decryptedText += DecryptLetter(input_text[i], decryptedText[keyIterator]);
                        keyIterator += 1;
                    }
                    currentPos += 1;
                }
                else
                {
                    decryptedText += input_text[i];
                }
            }
            return decryptedText;
        }

        public static string EncryptText(string input_text, string keyDefault)
        {
            string key = CipherGeneralFunctions.GetOnlyUpperLettersText(keyDefault);
            if (key.Length == 0) { key += 'A'; }
            string encryptedText = string.Empty;
            int currentPos = 0;
            int keyIterator = 0;
            for (int i = 0; i < input_text.Length; i++)
            {
                //check if the character is a letter
                if (CipherGeneralFunctions.CheckLetter(input_text[i]) != -1)
                {
                    if (currentPos < key.Length)
                    {
                        //encrypt the letter using the key letter
                        encryptedText += EncryptLetter(input_text[i], key[currentPos]);
                    }
                    else
                    {
                        //encrypt the letter using the letter previously encrypt
                        while (CipherGeneralFunctions.CheckLetter(input_text[keyIterator]) == -1)
                        {
                            keyIterator += 1;
                        }
                        encryptedText += EncryptLetter(input_text[i], input_text[keyIterator]);
                        keyIterator += 1;
                    }
                    currentPos += 1;
                }
                else
                {
                    encryptedText += input_text[i];
                }
            }
            return encryptedText;
        }
    }
}
