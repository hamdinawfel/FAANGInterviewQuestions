using System;
using System.Text;

namespace FAANGInterviewQuestions.StacksAndQueue
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-remove-to-make-valid-parentheses/
    /// </summary>
    public static class MinimumBracketsToRemove
    {
        public static void Execute()
        {
            //var s = "lee(t(c)o)de)";
            //var s = "(a(b(c)d)";
            var s = "))((";
            //var s = "a)b(c)d";
            //var s = ")))))";
            Console.WriteLine(MinRemoveToMakeValid(s));
            
        }

        //OWN SOLUTION
        public static string MinRemoveToMakeValid0(string s)
        {
            var braketIndexes = new Stack<int>();
            var output = new StringBuilder(s);
            var removedNb = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    var lastIndex = braketIndexes.LastOrDefault();
                    if(braketIndexes.Count > 0)
                    {
                        if (s[lastIndex] == ')')
                        {
                            braketIndexes.Pop();
                        }
                        else
                        {
                            braketIndexes.Push(i);
                        }
                    }
                    else
                    {
                        braketIndexes.Push(i);
                    }
                }
                else if(s[i] == ')')
                {
                    var lastIndex = braketIndexes.LastOrDefault();
                    if (braketIndexes.Count > 0)
                    {
                        if (s[lastIndex] == '(')
                        {
                            braketIndexes.Pop();
                        }
                        else
                        {
                            output.Remove(i - removedNb, 1);
                            removedNb++;
                        }
                    }
                    else
                    {
                        output.Remove(i - removedNb, 1);
                        removedNb++;
                    }
                }
            }

            foreach (var index in braketIndexes)
            {
                output.Remove(index - removedNb, 1);
            }
            return output.ToString();
        }

        //SLOTION / T: O(N) , S:O(N)
        public static string MinRemoveToMakeValid(string s)
        {
            var stack = new Stack<int>();
            int removedCount = 0;
            var output = new StringBuilder(s);
            for(int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                }else if (output[i] == ')' && stack.Count > 0)
                {
                    stack.Pop();
                }else if(s[i] == ')')
                {
                    output.Remove(i - removedCount, 1);
                    removedCount++;
                }
            }
            while (stack.Count > 0)
            {
                var currentIndex = stack.Pop();
                output.Remove(currentIndex - removedCount, 1);
            }

            return output.ToString();
        }

    }
}
