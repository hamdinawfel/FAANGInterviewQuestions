using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANGInterviewQuestions.CodingGame
{
    public static class FindSumPairs
    {
        public static void Execute()
        {
            //var nums = new int[] { 1, 5, 8, 1, 2 }; var k = 13;
            //var nums = new int[] { 1, 3, 7, 9, 2 }; var k = 11;
            var nums = new int[] { 3, 2, 4 }; var k = 6;
            
            var result = FindSumPair(nums, k);
            Console.WriteLine("---------------");
            Console.WriteLine(string.Join(",", result));
        }

        public static int[] FindSumPair(int[] nums, int k)
        {
            var keyPairs = new Dictionary<int, int>(); // diff - position
            for (int i = 0; i < nums.Length; i++)
            {
                var valueToFind = k - nums[i];

                if (!keyPairs.ContainsKey(nums[i]))
                {
                    keyPairs[valueToFind] = i;
                }
                else
                {
                    return new int[] { keyPairs[nums[i]], i };
                }
                
            }

            return new int[] {0,0};
        }
    }
}
