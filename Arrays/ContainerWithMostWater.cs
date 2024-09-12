using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANGInterviewQuestions.Arrays
{
    /// <summary>
    /// https://leetcode.com/problems/container-with-most-water/description/
    /// | | |
    /// </summary>
    public static class ContainerWithMostWater
    {
        public static void Execute()
        {
            var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            var result = MaxArea(height);
            Console.WriteLine(result);
        }

        public static int MaxArea(int[] height)
        {
            var areas = new List<int>();
            for (int i = 0; i < height.Length; i++)
            {
               for(int j = i; j < height.Length; j++)
               {
                    if (i == j) continue;
                    var width = j - i;
                    var area = width * Math.Min(height[i], height[j]);
                    areas.Add(area);
                    
               }
            }

            return areas.Max();
        }
    }
}
