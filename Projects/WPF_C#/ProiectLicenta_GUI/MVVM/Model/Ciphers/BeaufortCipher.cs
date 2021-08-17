using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model.Ciphers
{
    /// <summary>
    /// The class for the Beaufort Cipher
    /// </summary>
    public class BeaufortCipher
    {
        //The constructor
        public BeaufortCipher()
        {

        }

        public static string BeaufortEncryptDecrypt(string txt, string keyDefault)
        {
            string key = CipherGeneralFunctions.GetOnlyUpperLettersText(keyDefault);
            if(key.Length == 0) { key += 'A'; }
            string EncryptedDecryptedTxt = string.Empty;
            //Get the alphabet to be easier to search a letter
            string alphabet = string.Empty;
            char auxLetter = 'A';
            while (auxLetter <= 'Z')
            {
                alphabet += auxLetter;
                auxLetter = (char)(auxLetter+1);
            }
            int keyIterator = 0;
            for (int i = 0; i < txt.Length; i++)
            {
                //Check to see if the character is a letter
                //if it is, modify it, if not, leave it as it is
                if (CipherGeneralFunctions.CheckLetter(txt[i]) != -1)
                {
                    //Get the position of the normal letter
                    int txtLetterPos = 0;
                    char txtLetter = txt[i];
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        //check to see if this is the position of the letter
                        if ((alphabet[j] == txtLetter) || (alphabet[j] + ('a' - 'A') == txtLetter))
                        {
                            //we found the position of the normal letter in the alphabet
                            txtLetterPos = j;
                            break;
                        }
                    }
                    //Get the offset for the key letter
                    int newLetterOffSet = 0;
                    char keyLetter = key[keyIterator % key.Length];
                    keyIterator += 1;
                    for (int j = txtLetterPos; j < txtLetterPos + alphabet.Length; j++)
                    {
                        //search for the positition of the key letter
                        int letterPos = j % alphabet.Length;
                        if ((alphabet[letterPos] == keyLetter) || (alphabet[letterPos] + ('a' - 'A') == keyLetter))
                        {
                            //we found the position of the key letter
                            break;
                        }
                        newLetterOffSet++;
                    }
                    //Add the encrypted/decrypted letter to the new text
                    if (CipherGeneralFunctions.CheckLetter(txt[i]) == 0)
                    {
                        //if the original letter is lower case, make the new one lower case too
                        EncryptedDecryptedTxt += (char)(alphabet[newLetterOffSet] + 32);
                    }
                    else
                    {
                        //else, add it normaly
                        EncryptedDecryptedTxt += alphabet[newLetterOffSet];
                    }
                }
                else
                {
                    //if the character is not a letter, add it normaly
                    EncryptedDecryptedTxt += txt[i];
                }
            }
            //return the new text
            return EncryptedDecryptedTxt;
        }
    }
}
