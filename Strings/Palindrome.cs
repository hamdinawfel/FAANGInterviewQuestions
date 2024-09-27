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
            //var s1 = "abb";
            //var s1 = ".,";
            Console.WriteLine(IsPalindrome(s1));
            //Output: true
            //Explanation: "amanaplanacanalpanama" is a palindrome.

        }

        public static bool IsPalindrome(string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
               if(!char.IsWhiteSpace(c) && (char.IsLetter(c) || char.IsDigit(c)))
               {
                    sb.Append(char.ToLower(c));
               }
            }

            if (sb.Length >= 2)
            {

                if(sb.Length == 0 || sb.Length == 1)
                {
                    return true;
                }
                else
                {
                    var left = sb.ToString().Substring(0, sb.Length / 2);
                    var right = sb.ToString().Substring((sb.Length / 2) + sb.Length % 2);
                    for ( var i = 0; i < left.Length; i++)
                    {
                        if (left[i] != right[left.Length -1 - i]) return false;
                    }
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
