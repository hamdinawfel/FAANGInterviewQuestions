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
            var s = "a#c"; var t = "b";
            var result = BackspaceCompare(s, t);
            Console.WriteLine(result);
        }

        public static bool BackspaceCompare(string s, string t)
        {
            return CleanUpString(s) == CleanUpString(t);
        }

        private static string CleanUpString(string input)
        {
            var sb = new StringBuilder(input);
            while (sb.ToString().Any(c => c == '#'))
            {
                if (sb[0] == '#')
                {
                    sb.Remove(sb.ToString().IndexOf('#'), 1);
                    continue;
                }

                sb.Remove(sb.ToString().IndexOf('#') - 1, 2);
            }
            return sb.ToString();
        }

        //After hint
        //TIME : O(a+b) 
        // SPACE : O(a+b)
        public static bool BackspaceCompare1(string s, string t)
        {
            var cleanedS = CleanUpString1(s); //T: O(a)
            var cleanedT = CleanUpString1(t);//T: O(b)

            if (cleanedS.Count != cleanedT.Count) return false; // O(1)

            return cleanedS.SequenceEqual(cleanedT); //T: O(a) or O(b) 

        }                                           // => O(2a +b) OR O(a + 2b)
                                                    // O(a+b)

        //TIME : O(N)
        //SAPCE : O(N)
        private static Stack<char> CleanUpString1(string input)
        {
            var output = new Stack<char>();

            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] != '#')
                {
                    output.Push(input[i]);
                }
                else
                {
                    if(output.Count > 0)
                    {
                        output.Pop();
                    }
                }
            }

            return output;
        }

        
    }
}
