using System.Text;
using System.Text.RegularExpressions;

namespace FAANGInterviewQuestions.Strings
{
    /// <summary>
    /// https://leetcode.com/problems/valid-palindrome/description/
    /// </summary>
    public static class Palindrome
    {
        public static void Execute()
        {
            var s = "cbbcc";
            //var s1 = "0b";
            //var s1 = ",; W;:GlG:;l ;,";
            var s1 = "Suuv,5?tt?5,vYYS";
            var s2 = "race a car";
            //var s1 = "abb";
            //var s1 = ".,";
            //Console.WriteLine(IsPalindrome2(s));
            Console.WriteLine(ValidPalindrome(s));
            //Output: true
            //Explanation: "amanaplanacanalpanama" is a palindrome.

        }

        //MINE 
        public static bool IsPalindrome(string s)
        {
            var sb = CleanUp(s);

            var p1 = sb.Length / 2 - 1;
            var p2 = sb.Length % 2 == 0 ? sb.Length / 2 : sb.Length / 2 + 1;
            if (sb.Length == 0 || sb.Length == 1)
            {
                return true;
            }
            else if (sb.Length == 2)
            {
                return sb[0] == sb[1];
            }
            else
            {
                while (p1 >= 0 && p2 < sb.Length)
                {
                    if (sb[p1] != sb[p2])
                    {
                        return false;
                    }
                    else
                    {
                        p1--;
                        p2++;
                    }
                }
            }

            return true;
        }

        //AFTER HINT: P1 = 0 ; P2 = s.Length -1 and GO to the middel
        public static bool IsPalindrome1(string s)
        {
            return false;
        }

        //AFTER HINT: P1 = Middle ; P2 = Middle and GO to the extrimity
        public static bool IsPalindrome2(string s)
        {
            var sb = new StringBuilder(Regex.Replace(s, @"[^A-Za-z0-9]", "").ToLower());

            var isLenghtEven = sb.Length % 2 == 0;
            var p1 = isLenghtEven? sb.Length / 2 : sb.Length / 2 -1; 
            var p2 = isLenghtEven ? p1 +1 : p1 + 2;
            while(p1>=0 && p2 < sb.Length)
            {
                if (sb[p1] != sb[p2])
                {
                    return false;
                }
                else
                {
                    p1--;
                    p2++;
                }
            }
            return true;
        }

        //AFTER HINT: clean up - reverse - and compare
        public static bool IsPalindrome3(string s)
        {
            var sb = CleanUp(s);
            var reversed = string.Join("",sb.ToString().Reverse());
            return reversed.Equals(sb.ToString());

        }

        private static StringBuilder CleanUp(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsWhiteSpace(c) && (char.IsLetter(c) || char.IsDigit(c)))
                {
                    sb.Append(char.ToLower(c));
                }
            }
            return sb;
        }

        public static bool ValidPalindrome(string s)
        {
            var left = 0; var right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return IsSubPalindrome(s, left + 1, right) || IsSubPalindrome(s, left, right - 1);
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }
        private static bool IsSubPalindrome(string s, int left, int right)
        {
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                else
                {
                    left++;
                    right--;
                }
            }
            return true;
        }
    }
}
