using System;

namespace HomeWork1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task 1");

            (int number, bool expected)[] testCases =
            {
                (19,true),
                (16,false),
                (12,false),
                (-2,true),
                (30,false),
            };
            foreach (var (number, expected) in testCases)
            {
                var result = IsPrimeNumber(number);
                var assert = result == expected;
                Console.WriteLine($"\nNumber: {number}, Result: {result}, Assert: {assert}");
            }

            Console.WriteLine("\nTask 3");

            (int number, int expected)[] testCases1 =
            {
                (0,0),
                (1,1),
                (2,1),
                (3,2),
                (4,3),
                (5,5),
            };

            foreach (var testCase1 in testCases1)
            {
                var recursive = RecursiveFibonacci(testCase1.number);
                var loop = LoopFibonacci(testCase1.number);
                var assert = recursive == loop && recursive == testCase1.expected;
                Console.WriteLine($"\nNumber {testCase1.number}, Recursive {recursive}, Loop {loop}, Assert {assert}");
            }
            Console.ReadLine();
        }
        public static bool IsPrimeNumber(int n)
        {
            int d = 0;
            int i = 2;

            while (i < n)
            {
                if (n % i == 0)
                    d++;
                i++;
            }

            return d == 0;
        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;                                                 // o(1)
                                                                         //
            for (int i = 0; i < inputArray.Length; i++)                  // O(n)
            {                                                            //
                for (int j = 0; j < inputArray.Length; j++)              // O(n)
                {                                                        //
                    for (int k = 0; k < inputArray.Length; k++)          // O(n)
                    {                                                    //
                        int y = 0;                                       //
                                                                         //
                        if (j != 0)                                      //
                        {                                                //
                            y = k / j;                                   // O(1)
                        }

                        sum += inputArray[i] + i + k + j + y;            // 
                    }                                                    //
                }                                                        //
            }                                                            //

            return sum;                                                  // O(1)
        }                                                                // O(N^3)
        public static int RecursiveFibonacci(int number) =>
            number switch
            {
                0 => 0,
                1 => 1,
                _ => RecursiveFibonacci(number - 2) + RecursiveFibonacci(number - 1)
            };

        public static int LoopFibonacci(int number)
        {
            if (number == 0) return 0;
            if (number == 1) return 1;

            var prev = 0;
            var cur = 1;

            for (var i = 2; i <= number; i++)
            {
                var temp = prev + cur;
                prev = cur;
                cur = temp;
            }

            return cur;
        }
    }
}
