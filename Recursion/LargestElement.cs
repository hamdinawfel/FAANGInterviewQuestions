namespace FAANGInterviewQuestions.Recursion
{
    /// <summary>
    /// https://leetcode.com/problems/kth-largest-element-in-an-array/description/
    /// </summary>
    public static class LargestElement
    {
        public static void Execute()
        {
            var nums = new int[] { 3, 2, 1, 5, 6, 4 }; var k = 2;
            //Console.WriteLine(FindKthLargest(nums, k));

            var array = new int[] { 73, 57, 49, 99, 133, 20, 1 };
            var expected = new int[] { 1, 20, 49, 57, 73, 99, 133 };

            //var rusult = SortArray(array, 0, array.Length - 1);
            //Console.WriteLine(string.Join(",", rusult));
            //Console.WriteLine(string.Join(",", expected));
            //------------
            var indexToFind = nums.Length - k;
            QuickSort(nums, 0, nums.Length - 1);
            Console.WriteLine(string.Join(",", nums));
            Console.WriteLine(nums[indexToFind]);
        }

        //with sorting
        public static int FindKthLargest0(int[] nums, int k)
        {
            var sortedArr = nums.OrderBy(x => x).ToArray();
            return sortedArr[nums.Length - k];
        }

        public static int FindKthLargest(int[] nums, int k)
        {
            var sortedArr = SortArray(nums, 0, nums.Length - 1);
            return sortedArr[nums.Length - k];
        }

        //73, 57, 49, 99, 133, 20, 1
        public static int[] SortArray(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];

            while(i <= j )
            {
                while(array[i] < pivot)
                {
                    i++;
                }
                while (array[j] < pivot)
                {
                    j--;
                }

                if(i <= j)
                {
                    var temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
                
            }
            if (leftIndex < j)
                SortArray(array, leftIndex, j);

            if (i < rightIndex)
                SortArray(array, i, rightIndex);

            return array;
        }

        //SOLOTION 
        public static void QuickSort(int[] nums, int left, int right)
        {
            if(left < right)
            {
                var partitionIndex = GetPartitionIndex(nums, left, right);
                QuickSort(nums, left, partitionIndex - 1);
                QuickSort(nums, partitionIndex + 1, right);
            }
        }
        private static int GetPartitionIndex(int[] nums, int left, int right)
        {
            var pivot = nums[right];
            var partitionIndex = left;
            for(var j = left; j < right; j++)
            {
                if (nums[j] <= pivot)
                {
                    Swap(nums, partitionIndex, j);
                    partitionIndex++;
                }
            }
            Swap(nums, partitionIndex, right); //Figure out why this line
            return partitionIndex;
        }

        private static void Swap(int[] nums, int i, int j)
        {
            var temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;

        }

    }
}
