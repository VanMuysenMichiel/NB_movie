using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TakeHomeExam_VanMuysenMichiel
{
    class Check
    {
        public bool CheckSentence(string input)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            bool languageCheck = regex.IsMatch(input);

            string[] length = input.Split(" ");

            if (languageCheck == true && length.Length > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
