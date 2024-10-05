namespace FAANGInterviewQuestions.StacksAndQueue
{
    /// <summary>
    /// https://leetcode.com/problems/implement-queue-using-stacks/
    /// </summary>
    public static class QueueWithStacks
    {
        public static void Execute()
        {
            MyQueue obj = new MyQueue();
            obj.Push(1);
        }
       

    }
    public class MyQueue
    {
        private Stack<int> _stack1 = new Stack<int>();
        private Stack<int> _stack2 = new Stack<int>();
        public MyQueue()
        {
            //_stack = stack;
            //_aux = stack;
        }

        public void Push(int x)
        {
            _stack1.Push(x);
        }

        public int Pop()
        {
            if(_stack2.Count == 0)
            {
                while(_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
            return _stack1.Pop();   
        }

        public int Peek()
        {
            if (_stack2.Count == 0)
            {
                while (_stack1.Count > 0)
                {
                    _stack2.Push(_stack1.Pop());
                }
            }
            return _stack1.Peek();
        }

        public bool Empty()
        {
            return _stack1.Count == 0 && _stack2.Count == 0;
        }
    }
}
