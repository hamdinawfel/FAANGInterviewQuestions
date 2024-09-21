using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANGInterviewQuestions.Arrays
{
    public static class CalculateTotalPrice
    {
        public static void Execute()
        {
            var prices = new int[] { 100, 200, 30, 55 };
            decimal discount = 0.2M;
            var total = Calculate(prices, discount);
            Console.WriteLine(total);
        }
        public static int Calculate(int[] prices, decimal discount)
        {
            var total = prices.Sum(x => x) - (prices.Max() * discount);
            return (int)Math.Round(total);
        }
    }
}
