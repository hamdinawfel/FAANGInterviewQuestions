using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANGInterviewQuestions.Arrays
{
    public class RecursiveFibonacci
    {
        public static int CalculateRecursiveFibonacci(int n)
        {
            if (n < 2) return n;
            return CalculateRecursiveFibonacci(n - 1) + CalculateRecursiveFibonacci(n - 2);
        }
    }
}
