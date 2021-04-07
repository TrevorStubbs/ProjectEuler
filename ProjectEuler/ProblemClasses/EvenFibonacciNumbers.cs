using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.ProblemClasses
{
    public static class EvenFibonacciNumbers
    {
        public static int SumOfEvenNumbers(int limit)
        {
            int value = 1;
            int oldValue = 0;
            int output = 0;
            while (value < limit)
            {
                int temp = oldValue;
                oldValue = value;
                value += temp;

                if (value % 2 == 0)
                    output += value;
            }

            return output;
        }

        public static void RunFib(int limit)
        {
            int value = 1;
            int oldValue = 0;
            while(value < limit)
            {
                int temp = oldValue;
                oldValue = value;
                value += temp;

                Console.Write($"{value} ");
            }

            Console.WriteLine();
        }


    }
}
