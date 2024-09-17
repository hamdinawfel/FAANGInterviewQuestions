using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAANGInterviewQuestions.Arrays
{
    /// <summary>
    /// https://leetcode.com/problems/trapping-rain-water/
    /// </summary>
    public static class TrappingRainWater
    {
        public static void Execute()
        {
            var height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //var height = new int[] { 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            //var height = new int[] { 4, 2, 0, 3, 2, 5 };
            //var height = new int[] { 2, 0, 2 };
            //var height = new int[] { 4, 2, 3 };
            var result1 = Trap(height);
            Console.WriteLine(result1);
        }
        public static int Trap0(int[] height)
        {
            var maxWater = 0; 
            var p1 = 0; 
            
            while(p1< height.Length - 1)
            {
                var subArray = height.Skip(p1+1).ToArray();
                if (!subArray.Any(x => x >= height[p1]))
                {
                    p1++;
                    continue;
                }
                var p2 = Array.IndexOf(subArray, subArray.FirstOrDefault(x => x >= height[p1])) + p1 + 1;
               
                var h = Math.Min(subArray.FirstOrDefault(x => x >= height[p1]), height[p1]);

                var maxArea = (p2 - p1) * h;
                var filledArea = 0;
                for (var i = p1; i < p2; i++)
                {
                    filledArea += height[i];
                }
                maxWater += maxArea - filledArea;
                p1 = p2;
            }
            return maxWater;

        }

        public static int Trap00(int[] height)
        {
            var maxWater = 0;
            var p1 = 0;
            while (p1 < height.Length - 1)
            {
                if (height[p1 + 1] > height[p1])
                {
                    p1++;
                    continue;
                }

                var nextMin = height[p1];
                var nextMinIndex = p1;
                for (var i  = p1 + 1; i < height.Length - 1; i++)
                {
                    if (height[i] < nextMin && height.Skip(i+1).ToArray().Any(h => h > height[i]))
                    {
                        nextMin = height[i];
                        nextMinIndex = i;

                    }
                }

                var nextMax = height.Skip(nextMinIndex + 1).ToArray().FirstOrDefault(h => h > nextMin);
                var nextMaxIndex = Array.IndexOf(height.Skip(nextMinIndex + 1).ToArray(), nextMax) + nextMinIndex + 1;

                var h = Math.Min(nextMax, height[p1]);

                var maxArea = (nextMaxIndex - p1) * h;
                var filledArea = 0;
                for (var i = p1; i < nextMaxIndex; i++)
                {
                    filledArea += height[i];
                }
                maxWater += maxArea - filledArea;
                p1 = nextMaxIndex;
            }
            return maxWater;

        }

        public static int Trap000(int[] height)
        {
            var maxWater = 0;
            var containers = new List<List<int>>();
            var perm = new List<int>();
            var p = 0;
            
            bool isFirstBorderExist = false;

            if(p == 6)
            {
                bool s = false;
            }
            while(p < height.Length - 1)
            {
                if (height[p + 1]< height[p])
                {
                    isFirstBorderExist = true;
                }
                var skipper = containers.Sum(x => x.Count);
                perm = height.Skip(skipper - 1).Take(p - skipper +1).ToList();
                p++;
                if (perm.Count > 0 && p < height.Length - 2 && isFirstBorderExist && height[p +1] < height[p] && height[p] >= perm.Max())
                {
                    isFirstBorderExist = false;
                    perm.Add(height[p]);
                    containers.Add(new List<int>(perm));
                    perm.Clear();
                }
                if (p == height.Length - 2)
                {
                    var skip = 0;
                    containers.ForEach(c =>
                    {
                        skip += c.Count - 1;
                    });

                    perm = height.Skip(skip + 1).ToList();
                    containers.Add(new List<int>(perm));
                    perm.Clear();
                }
            }

            foreach(var container in containers)
            {

                var p1 = 0;
                var p2 = container.Count - 1;
                var maxArea = 0;
                while (p1 < p2)
                {
                    var w = p2 - p1;
                    var h = Math.Min(container[p1], container[p2]);
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
              
                maxWater += maxArea - container.Skip(1).Take(container.Count - 2).Sum(x => x);
            }

            return maxWater;
        }

        public static int Trap(int[] height)
        {
            var maxWater = 0;
            for(var i = 1; i < height.Length - 1; i++)
            {
                var leftMax = height.Take(i).Max() > height[i] ?height.Take(i).Max() : height[i];
                var rightMax = height.Skip(i).Max();
                var h = Math.Min(leftMax, rightMax) - height[i];

                maxWater += h;
            }

            return maxWater;
        }
    }
}
