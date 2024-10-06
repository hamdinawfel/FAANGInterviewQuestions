namespace FAANGInterviewQuestions.Recursion
{
    /// <summary>
    /// https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/description/
    /// </summary>
    public static class FirstAndLastPosition
    {
        public static void Execute()
        {
            //var nums = new int[] { 5, 7, 7, 8, 8, 10 }; var target = 6;
            var nums = new int[] { 1, 1, 2 }; var target = 1;
            var result = SearchRange(nums, target);
            Console.WriteLine($"[{result[0]}, {result[1]}]");
        }

        //Own Solution
        public static int[] SearchRange(int[] nums, int target)
        {
            var result = new int[] { -1, -1 };
            var left = 0; var right = nums.Length - 1;
            while(left <= right)
            {
                int mid = (left + right) / 2;
                var foundedValue = nums[mid];
                if(foundedValue == target)
                {
                    var p1 = mid; var p2 = mid;
                    
                    while (p2 > 0 && nums[p1 - 1] == target)
                    {
                        p1--;
                    }
                    while (p2 < nums.Length- 1 && nums[p2 + 1] == target)
                    {
                        p2++;
                    }
                    result[0] = p1;
                    result[1] = p2;
                    return result;
                }
                else if (foundedValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
           

            return result;
        }

        //Correction S: O(1), T: O(log(N)

        public static int[] SearchRange1(int[] nums, int target)
        {
            if(nums.Length == 0) return new int[] { -1, -1 };
            var firstPosition = BinarySearch(nums,0, nums.Length -1, target);
            if(firstPosition == -1) return new int[] { -1, - 1 };

            var startPosition = firstPosition; 
            var endPositon = firstPosition;
            var temp1 = firstPosition; 
            var temp2 = firstPosition;
            while(startPosition != -1)
            {
                temp1 = startPosition;
                startPosition = BinarySearch(nums, 0, startPosition -1, target);
            }
            startPosition = temp1;
            while (endPositon != -1)
            {
                temp2 = endPositon;
                endPositon = BinarySearch(nums, endPositon + 1, nums.Length -1, target);
            }
            endPositon = temp2;
             
            return new int[] { startPosition, endPositon };
        }

        private static int BinarySearch(int[] nums, int left,int right, int target)
        {
            while(left <= right)
            {
                int mid = (left + right) / 2;
                var foundedValue = nums[mid];
                if(foundedValue == target)
                {
                    return mid;
                }else if(foundedValue < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1;
        }
    }
}
