using System.Text;

namespace FAANGInterviewQuestions.Strings
{
    /// <summary>
    /// https://leetcode.com/problems/valid-palindrome/description/
    /// </summary>
    public static class Palindrome
    {
        public static void Execute()
        {
            var s = "A man, a plan, a canal: Panama";
            //var s1 = "0b";
            //var s1 = ",; W;:GlG:;l ;,";
            var s1 = "Suuv,5?tt?5,vYYS";
            var s2 = "race a car";
            //var s1 = "abb";
            //var s1 = ".,";
            Console.WriteLine(IsPalindrome3(s));
            //Output: true
            //Explanation: "amanaplanacanalpanama" is a palindrome.

        }

        //MINE 
        public static bool IsPalindrome(string s)
        {
            var sb = CleanUp(s);

            if (sb.Length >= 2)
            {
                var left = sb.ToString().Substring(0, sb.Length / 2);
                var right = sb.ToString().Substring((sb.Length / 2) + sb.Length % 2);
                for (var i = 0; i < left.Length; i++)
                {
                    if (left[i] != right[left.Length - 1 - i])
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        //AFTER HINT: P1 = 0 ; P2 = s.Length -1 and GO to the middel
        public static bool IsPalindrome1(string s)
        {
            return false;
        }

        //AFTER HINT: P1 = Middle ; P2 = Middle and GO to the extrimity
        public static bool IsPalindrome2(string s)
        {
            return false;
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
    }
}
