using ProjectEuler.ProblemClasses;
using System;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine();

            Console.WriteLine(MultiplesOf3and5.SumOfMultiplesOf3and5(1000));

            Console.WriteLine();

            EvenFibonacciNumbers.RunFib(89);

            Console.WriteLine();

            Console.WriteLine(EvenFibonacciNumbers.SumOfEvenNumbers(4000000));
        }
    }
}
