namespace FAANGInterviewQuestions.Arrays
{
    /// <summary>
    /// https://leetcode.com/problems/two-sum/description/
    /// </summary>
    public static class ArraysTwoSum
    {
        public static void Execute()
        {
            var numbers = new int[] { 1, 3, 7, 9, 2 }; 
            var result1 = Calcualte(numbers, 11);
            var result2 = Calcualte2(numbers, 11);
            var result3 = Calcualte3(numbers, 11);
            var result4 = Calcualte4(numbers, 11);
            Console.WriteLine(string.Join(',', result1));
            Console.WriteLine(string.Join(',', result3));
            Console.WriteLine(string.Join(',', result4));
            Console.WriteLine(result2);
        }
        //MY SOLUTION
        public static int[] Calcualte(int[] nums, int target)
        {
            foreach (var n in nums)
            {
                var x = target - n; 
                var list = nums.ToList();
                list.Remove(n);
                if (list.Contains(x))
                {
                    return new int[] {
                        Array.IndexOf(nums, n),
                        Array.IndexOf(nums.Skip(Array.IndexOf(nums, n) + 1).ToArray(), x) + Array.IndexOf(nums, n) + 1
                    };
                }
            }
            return null;
        }

        //COORECTION 1
        public static string Calcualte2(int[] numbers, int target)
        {
            for(int i = 0; i < numbers.Length; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if (numbers[j] == target - numbers[i])
                    {
                        return $"{i}, {j}";
                    }
                }
            }
            return null;
        }

        //COORECTION 2
        public static int[] Calcualte3(int[] nums, int target)
        {
            Dictionary<int, int> mapVal = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i ++)
            {
                var valToFind = target - nums[i];
                if (!mapVal.ContainsKey(nums[i]))
                {
                    mapVal[valToFind] = i;
                }
                else
                {
                    return new int[] { mapVal[nums[i]], i };
                }
            }

            return null;
        }

        public static int[] Calcualte4(int[] nums, int target)
        {
            Dictionary<int, int> keyValuePairs = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i ++ )
            {
                if (keyValuePairs.ContainsKey(nums[i]))
                {
                    return new int[] { keyValuePairs[nums[i]], i };
                }
                else
                {
                    var valueToFind = target - nums[i];
                    keyValuePairs.Add(valueToFind, i);
                }
            }

            return null;
        }
    }
}
