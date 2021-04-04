using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.ProblemClasses
{
    public static class MultiplesOf3and5
    {
        public static int SumOfMultiplesOf3and5(int input)
        {
            var outputNumber = 0;
            for (int i = 1; i < input; i++)
            {
                if(i % 3 == 0 || i % 5 == 0)
                {
                    outputNumber += i;
                }
            }

            return outputNumber;
        }
    }
}
