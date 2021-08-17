using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectLicenta_GUI.MVVM.Model.Ciphers
{
    /// <summary>
    /// A class for static methods refferenced by multiple ciphers to not write
    /// duplicate code.
    /// </summary>
    public class CipherGeneralFunctions
    {
        public static int CheckLetter(char letter)
        {
            // returns 1 if the letter is upper case
            // returns 0 if the letter is lower case
            // returns -1 if the symbol is not a letter
            if (letter >= 'A' && letter <= 'Z')
            {
                return 1;
            }
            if (letter >= 'a' && letter <= 'z')
            {
                return 0;
            }
            return -1;
        }

        public static string GetOnlyUpperLettersText(string txt)
        {
            //Return a string that contains ONLY the alphabetical characters of a text (Uppercased)
            string newTxt = string.Empty;
            for (int i = 0; i < txt.Length; i++)
            {
                if (!((txt[i] < 'A' || txt[i] > 'Z') && (txt[i] < 'a' || txt[i] > 'z')))
                {
                    if (txt[i] >= 'a' && txt[i] <= 'z')
                    {
                        newTxt += (char)(txt[i] - ('a' - 'A'));
                    }
                    else
                    {
                        newTxt += txt[i];
                    }
                }
            }
            return newTxt;
        }
    }
}
