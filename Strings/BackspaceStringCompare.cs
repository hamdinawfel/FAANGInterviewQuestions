using System.Text;

namespace FAANGInterviewQuestions.Strings
{
    /// <summary>
    /// https://leetcode.com/problems/backspace-string-compare/description/
    /// </summary>
    public static class BackspaceStringCompare
    {
        public static void Execute()
        {
            //var s = "ad#c"; var t = "ab#c";
            //var s = "ab##"; var t = "c#d#";
            var s = "#a#c"; var t = "a##c";
            var result = BackspaceCompare(s, t);
            Console.WriteLine(result);
        }

        public static bool BackspaceCompare(string s, string t)
        {
            var ssb = new StringBuilder(s);
            var tsb = new StringBuilder(t);
           
            while (ssb.ToString().Any(c => c == '#'))
            {
                if (ssb[0] == '#')
                {
                    ssb.Remove(ssb.ToString().IndexOf('#'), 1);
                    continue;
                }
                
                ssb.Remove(ssb.ToString().IndexOf('#') - 1, 2);
            }

            while (tsb.ToString().Any(c => c == '#'))
            {
                if (tsb[0] == '#')
                {
                    tsb.Remove(tsb.ToString().IndexOf('#'), 1);
                    continue;
                }

                tsb.Remove(tsb.ToString().IndexOf('#') - 1, 2);
            }

            return ssb.ToString() == tsb.ToString();
        }
    }
}
