namespace FAANGInterviewQuestions.StacksAndQueue
{
    /// <summary>
    /// https://leetcode.com/problems/valid-parentheses/
    /// </summary>
    public static class ValidParentheses
    {
        public static void Execute()
        {
            //var s = "((";
            //var s = "){";
            var s = "()[]{}";
            Console.WriteLine(IsValid(s));
        }

        //Own s
        public static bool IsValid0(string s)
        {
            var stack = new Stack<char>();
            
            if(string.IsNullOrEmpty(s)) return true;
            if (s.Length == 1) return false;

            foreach (var c in s)
            {
               if(c == '(' || c == '[' || c == '{')
               {
                   stack.Push(c);
                }
                else
                {
                    if(stack.Count == 0) return false;
                    var lastInput = stack.Pop();
                    if((c == ')' && lastInput == '(') || (c == ']' && lastInput == '[') || (c == '}' && lastInput == '{'))
                    {
                        continue;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            return stack.Count() == 0;

        }

        public static bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var parentheses = new Dictionary<char, char>
            {
                {'{' , '}' },
                {'[' , ']' },
                {'(' , ')' },
            };
            if(string.IsNullOrEmpty(s)) return true;
            if(s.Length == 1) return false;
            for (var i = 0;  i < s.Length; i++)
            {
                if (parentheses.ContainsKey(s[i]))
                {
                    stack.Push(s[i]);
                }
                else
                {
                    var leftBraket = stack.Pop();
                    var correctBraket = parentheses[leftBraket];
                    if (s[i] != correctBraket) return false;
                   
                }
            }

            return stack.Count() == 0;

        }
    }
}
