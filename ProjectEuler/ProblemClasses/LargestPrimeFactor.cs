using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.ProblemClasses
{
    public static class LargestPrimeFactor
    {
        public static long FindLargesPrimeFactor(long inputNumber)
        {
            var primes = GeneratePrimes.GenerateAllPrimesForMaxValue(inputNumber);

            for (int i = primes.Count - 1; i > 0; i--)
            {
                if (inputNumber % primes[i] == 0)
                    return primes[i];
            }

            return 1;
        }
    }

    public class PrimeSeive
    {
        private int _size;
        private BitArray _bitArray;

        public PrimeSeive(int size)
        {
            _size = size;
            _bitArray = new BitArray((int)(_size + 1), true);
        }

        public List<int> GeneratePrimeList()
        {
            FindPrimes();

            var primeList = new List<int>();

            for (int i = 0; i < _bitArray.Length; i++)
            {
                if (_bitArray[i])
                {
                    primeList.Add(i);
                }
            }

            return primeList;
        }

        private void FindPrimes()
        {
            var numFactor = 3;
            var maxFactor = (int)Math.Sqrt(_size);

            while (numFactor < maxFactor)
            {
                for (int index = numFactor; index <= _size; index++)
                {
                    if (GetBit(index))
                    {
                        numFactor = index;
                        break;
                    }
                }

                for (int index = numFactor * 3; index <= _size; index += numFactor * 2)
                {
                    ClearBit(index);
                }
                
                numFactor += 2;         // Skip the even indexes
            }
        }

        private bool GetBit(int index)
        {
            if (index % 2 == 0)
                return false;
            return _bitArray[index];
        }

        private void ClearBit(int index)
        {
            if(index % 2 == 0)
            {
                Console.WriteLine("Looking at a even");
                return;
            }
            _bitArray[index] = false;
        }
    }

    public static class GeneratePrimes
    {
        public static List<long> GenerateAllPrimesForMaxValue(long maxValue)
        {
            var bitArraySize = (long)Math.Sqrt(maxValue) + 1;
            var bitArray = new BitArray((int)bitArraySize, true);

            bitArray[0] = false;
            bitArray[1] = false;

            for (int i = 2; i < bitArraySize; i++)
            {
                if(bitArray[i])
                {
                    for (int j = 2 * i; j < bitArraySize; j += i)
                    {
                        bitArray[j] = false;
                    }
                }
            }

            var primeList = new List<long>(bitArray.Count);

            for (int i = 0; i < bitArray.Count; i++)
            {
                if (bitArray[i])
                    primeList.Add(i);
            }

            return primeList;
        }
    }
}
