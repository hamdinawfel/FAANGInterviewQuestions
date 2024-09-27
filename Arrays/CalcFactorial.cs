using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANGInterviewQuestions.Arrays
{
    /// <summary>
    /// https://www.freecodecamp.org/news/big-o-cheat-sheet-time-complexity-chart/
    /// </summary>
    public static class CalcFactorial
    {
        public static void Execute()
        {
            var res = Calculate(5);
            var res2 = Calculate2(5);
            Console.WriteLine(res);
            Console.WriteLine(res2);
        }
        public static int Calculate(int n)
        {
            var factoriel = 1;
            for (var i = 2; i <= n; i++)
            {
                factoriel = factoriel * i;
            }
            return factoriel;
        }
        public static int Calculate2(int n)
        {
            if (n <= 1) return 1;

            return n * Calculate2(n - 1);
        }
    }
}
