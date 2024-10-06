namespace FAANGInterviewQuestions.Recursion
{
    public static class Factoriel
    {
        public static void Execute()
        {
            var x = 4;
            Console.WriteLine(NormlaRecursion(x));
            Console.WriteLine(TailRecursion(x));
        }

        //S: O(N)
        public static int NormlaRecursion(int x)
        {
            if(x <= 1)
            {
                return 1;
            }else
            {
                return x * NormlaRecursion(x - 1);
            }
        }

        //S: O(1)
        public static int TailRecursion(int x, int totalSofar = 1)
        {
            if(x == 0)
            { 
                return totalSofar;
            }
            else
            {
               return TailRecursion(x - 1, totalSofar * x);
            }
            
        }
    }
}
