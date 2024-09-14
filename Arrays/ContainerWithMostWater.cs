using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            //var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
            //var height = new int[] { 2, 3, 4, 5, 18, 17, 6 };
            //var height = new int[] { 1, 8, 6, 2, 5, 4, 8, 25, 7 };
            //var height = new int[] { 1,2 };
            //var height = new int[] { 1, 8, 100, 2, 100, 4, 8, 3, 7 };
            var height = new int[] { 1, 2, 4, 3 };
            //var height = new int[] { 1, 2, 1 };
            var result1 = MaxArea1(height);
            var result2 = MaxArea2(height);
            var result3 = MaxArea3(height);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }

        // Mine Solution 1
        public static int MaxArea1(int[] height)
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

        // Coorection 1
        // a = Min(b,a) * (bi - ai)
        // TIME : O(n*n)
        // SPACE : O(1)
        public static int MaxArea2(int[] height)
        {
            var maxArea = 0;
            for(int i = 0; i < height.Length;i++)
            {
                for(int j = i + 1; j < height.Length; j++)
                {
                    var h = Math.Min(height[i], height[j]);
                    var w = j - i;
                    var area = h * w;
                    maxArea = Math.Max(maxArea, area);
                }
            }
            return maxArea;
        }

        public static int MaxArea3(int[] height)
        {
            var p1 = 0;
            var p2 = height.Length - 1;
            var maxArea = 0;
            while (p1 < p2)
            {
                var w = p2 - p1;
                var h = Math.Min(height[p1], height[p2]);
                var area = h * w;   
                maxArea = Math.Max(maxArea, area);
                if(height[p1] <= height[p2])
                {
                    p1++;
                }else
                {
                    p2--;
                }
            }

            return maxArea;
        }
    }
}
