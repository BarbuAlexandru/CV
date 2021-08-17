using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model.Ciphers
{
    /// <summary>
    /// The class for the Playfair cipher
    /// </summary>
    public class PlayfairCipher
    {
        //The constructor
        public PlayfairCipher()
        {

        }

        public static int GetLetterFirstPos(char ch, string txt)
        {
            // if it founds the letter ch, it returns the first position
            // if not it returns -1
            for (int i = 0; i < txt.Length; i++)
            {
                if (ch == txt[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetKeyForPlayfairFromTxt(string txt)
        {
            //This function returns the actual key for
            //a playfair cipher (a 5x5 grid stored in a string)
            txt = CipherGeneralFunctions.GetOnlyUpperLettersText(txt);
            string key = string.Empty;
            int keyPos = 0;
            //add the letters from the given txt
            for (int i = 0; i < txt.Length; i++)
            {
                //check if the letter is not already in the key and
                //the letter is not J
                if (GetLetterFirstPos(txt[i], key) == -1 && (txt[i] != 'J'))
                {
                    //if it is not, add it
                    key += txt[i];
                    keyPos += 1;
                }
            }
            //add the remaining letters until the grid is complete
            for (int i = 'A'; i <= 'Z'; i++)
            {
                //check if the letter is not already in the key and if
                //the letter is not J - in playfair the key cannot contain J
                if (GetLetterFirstPos((char)(i), key) == -1 && (i != 'J'))
                {
                    //if it is not, add it to the key
                    key += (char)(i);
                    keyPos += 1;
                }
                if (keyPos >= 25)
                {
                    break;
                }
            }
            return key;
        }

        public static int GetXPosInKey(char ch, string key)
        {
            //returns the X position of the letter in the key
            return GetLetterFirstPos(ch, key) / 5;
        }
        public static int GetYPosInKey(char ch, string key)
        {
            //returns the Y position of the letter in the key
            return GetLetterFirstPos(ch, key) % 5;
        }

        public static char GetLetterFromKeyByPos(int x, int y, string key)
        {
            return key[x * 5 + y];
        }

        public static string EncryptText(string txtDefault, string keyDefault)
        {
            //change the text and the key to the Playfair format
            string txt = CipherGeneralFunctions.GetOnlyUpperLettersText(txtDefault);
            if (txt.Length == 0) { txt += 'A'; }
            string key = GetKeyForPlayfairFromTxt(keyDefault);
            //the encrypted text
            string encrypted_txt = string.Empty;

            //Add x at the end if the string has odd number of letters
            if (txt.Length % 2 != 0)
            {
                txt += 'X';
            }

            //get every pair of 2 consecutive letters in the text to encrypt them
            for (int i = 0; i < (txt.Length / 2); i++)
            {
                //get the letters
                char ch1 = txt[i * 2];
                char ch2 = txt[i * 2 + 1];

                //Check for duplicate letters and replace the duplicate with X
                if (ch1 == ch2)
                {
                    ch2 = 'X';
                }

                //check if a letter is J and replace it with X for simplicity
                if (ch1 == 'J')
                {
                    ch1 = 'X';
                }
                if (ch2 == 'J')
                {
                    ch2 = 'X';
                }

                //declare the encrypted letters
                char encrypted_ch1, encrypted_ch2;

                //encrypt the letterts
                if (GetXPosInKey(ch1, key) == GetXPosInKey(ch2, key))
                {
                    //the letters are in the same row in the key grid
                    //compute the new row number
                    int newRowCh1 = (GetYPosInKey(ch1, key) + 1) % 5;
                    int newRowCh2 = (GetYPosInKey(ch2, key) + 1) % 5;
                    //Encrypt the letters
                    encrypted_ch1 = GetLetterFromKeyByPos(GetXPosInKey(ch1, key), newRowCh1, key);
                    encrypted_ch2 = GetLetterFromKeyByPos(GetXPosInKey(ch2, key), newRowCh2, key);
                }
                else if (GetYPosInKey(ch1, key) == GetYPosInKey(ch2, key))
                {
                    //the letters are in the same column in the key grid
                    //compute the new column number
                    int newColCh1 = (GetXPosInKey(ch1, key) + 1) % 5;
                    int newColCh2 = (GetXPosInKey(ch2, key) + 1) % 5;
                    //Encrypt the letters
                    encrypted_ch1 = GetLetterFromKeyByPos(newColCh1, GetYPosInKey(ch1, key), key);
                    encrypted_ch2 = GetLetterFromKeyByPos(newColCh2, GetYPosInKey(ch2, key), key);
                }
                else
                {
                    //The letters have different columns and rows. get the letters from the square they form
                    encrypted_ch1 = GetLetterFromKeyByPos(GetXPosInKey(ch1, key), GetYPosInKey(ch2, key), key);
                    encrypted_ch2 = GetLetterFromKeyByPos(GetXPosInKey(ch2, key), GetYPosInKey(ch1, key), key);
                }

                //add the letters to the encrypted text
                encrypted_txt += encrypted_ch1;
                encrypted_txt += encrypted_ch2;
            }

            return encrypted_txt;
        }

        public static string DecryptText(string txtDefault, string keyDefault)
        {
            //change the text and the key to the Playfair format
            string txt = CipherGeneralFunctions.GetOnlyUpperLettersText(txtDefault);
            if (txt.Length == 0) { txt += 'A'; }
            string key = GetKeyForPlayfairFromTxt(keyDefault);
            //the decrypted text
            string decrypted_txt = string.Empty;

            //get every pair of 2 consecutive letters in the text to decrypt them
            for (int i = 0; i < (txt.Length / 2); i++)
            {
                //get the letters
                char ch1 = txt[i * 2];
                char ch2 = txt[i * 2 + 1];

                //declare the decrypted letters
                char decrypted_ch1, decrypted_ch2;

                //encrypt the letterts
                if (GetXPosInKey(ch1, key) == GetXPosInKey(ch2, key))
                {
                    //the letters are in the same row in the key grid
                    //compute the new row number
                    int newRowCh1 = GetYPosInKey(ch1, key) - 1;
                    int newRowCh2 = GetYPosInKey(ch2, key) - 1;
                    //make sure the new Positions are good (not negative)
                    if (newRowCh1 < 0)
                    {
                        newRowCh1 = 4;
                    }
                    if (newRowCh2 < 0)
                    {
                        newRowCh2 = 4;
                    }
                    //Encrypt the letters
                    decrypted_ch1 = GetLetterFromKeyByPos(GetXPosInKey(ch1, key), newRowCh1, key);
                    decrypted_ch2 = GetLetterFromKeyByPos(GetXPosInKey(ch2, key), newRowCh2, key);
                }
                else if (GetYPosInKey(ch1, key) == GetYPosInKey(ch2, key))
                {
                    //the letters are in the same column in the key grid
                    //compute the new column number
                    int newColCh1 = GetXPosInKey(ch1, key) - 1;
                    int newColCh2 = GetXPosInKey(ch2, key) - 1;
                    //make sure the new Positions are good (not negative)
                    if (newColCh1 < 0)
                    {
                        newColCh1 = 4;
                    }
                    if (newColCh2 < 0)
                    {
                        newColCh2 = 4;
                    }
                    //Encrypt the letters
                    decrypted_ch1 = GetLetterFromKeyByPos(newColCh1, GetYPosInKey(ch1, key), key);
                    decrypted_ch2 = GetLetterFromKeyByPos(newColCh2, GetYPosInKey(ch2, key), key);
                }
                else
                {
                    //The letters have different columns and rows. get the letters from the square they form
                    decrypted_ch1 = GetLetterFromKeyByPos(GetXPosInKey(ch1, key), GetYPosInKey(ch2, key), key);
                    decrypted_ch2 = GetLetterFromKeyByPos(GetXPosInKey(ch2, key), GetYPosInKey(ch1, key), key);
                }

                //add the letters to the encrypted text
                decrypted_txt += decrypted_ch1;
                decrypted_txt += decrypted_ch2;
            }
            return PlayfairResolveXs(decrypted_txt);
        }

        public static string PlayfairResolveXs(string txt)
        {
            //resolve the X's generated in the encryption
            string newTxt = string.Empty;
            for (int i = 0; i < (txt.Length / 2); i++)
            {
                //get the letters from each group of 2 consecutive letters
                char ch1 = txt[i * 2];
                char ch2 = txt[i * 2 + 1];

                //Always add the ch1
                newTxt += ch1;
                //resolve the Xs
                if (ch2 == 'X')
                {
                    if ((i * 2 + 1) == (txt.Length - 1))
                    {
                        //do nothing as this is the X added at the end
                    }
                    else
                    {
                        //replace the second letter with the first one
                        //but make it lower case to note that it might
                        //still be a normal X
                        newTxt += (char)(ch1 + 32);
                    }
                }
                else
                {
                    //if the second letter is not an X just add it normally
                    newTxt += ch2;
                }
            }
            return newTxt;
        }
    }
}
