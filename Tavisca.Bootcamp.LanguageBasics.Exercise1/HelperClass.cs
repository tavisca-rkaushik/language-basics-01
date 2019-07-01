using System;
using System.Collections.Generic;
using System.Text;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class HelperClass
    {
        public static int RequiredDigit(int num, int i)
        {
            int Reverse = 0;
            while (num > 0)
            {
                int remainder = num % 10;
                Reverse = (Reverse * 10) + remainder;
                num = num / 10;
            }
            int j = 0;
            while (Reverse > 0)
            {
                if (i == j)
                {
                    return Reverse % 10;
                }
                else
                {
                    Reverse /= 10;
                    j++;
                }
            }
            return -1;
        }

        public static bool ispossible(string str, int num)
        {
            var charsToRemove = new string[] { "?" };
            foreach (var c in charsToRemove)
            {
                str = str.Replace(c, string.Empty);
            }
            int compare = System.Convert.ToInt32(str);
            if (compare >= num) return false;
            return true;
        }
        public static string[] SplitString(string equation)
        {
            string s1 = "", s2 = "", s3 = "", temp = "";
            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '*')
                {
                    s1 = temp;
                    temp = "";
                }
                else if (equation[i] == '=')
                {
                    s2 = temp;
                    temp = "";
                }
                else if (i == equation.Length - 1)
                {
                    temp = temp + equation[i];
                    s3 = temp;
                }
                else temp = temp + equation[i];
            }
            string[] ans = { s1, s2, s3 };
            return ans;
        }
    }
}
