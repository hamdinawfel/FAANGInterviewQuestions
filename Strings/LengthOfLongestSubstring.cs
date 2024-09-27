using System.Linq;
using System.Text.RegularExpressions;

namespace FAANGInterviewQuestions.Strings
{
    public static class LengthOfLongestSubstring
    {
        public static void Execute()
        {
            //var s = "abcabcbb";
            //var s = "pwwkew";
            //var s = "";
            var s = "aab";
            //var s = "dvdf";
            //var s = "anviaj";
            var result = GetLengthOfLongestSubstring(s);
            Console.WriteLine(result);

        }
        public static int GetLengthOfLongestSubstring(string s)
        {
            var longest = 0;
            var sub = "";
            if (s.Length == 1) return 1;
            if (s == "") return 0;
            for (int i = 0; i < s.Length - 1; i ++)
            {
                for (int j = i; j < s.Length - 1; j++)
                {
                    longest = sub.Length > longest ? sub.Length : longest;
                    if (!sub.Any(x => x == s[j]))
                    {
                        sub += s[j];
                    }
                    else
                    {
                        
                        sub = "";
                        sub += s[i + 1];
                    }
                }
            }

            return longest;
        }
    }
}
