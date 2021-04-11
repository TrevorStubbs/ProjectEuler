using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEuler.ProblemClasses
{
    public static class LargestPalindromeProduct
    {

        // turn the products into strings
        public static int FindLargestPalindrome()
        {
            var productList = GenerateProductsFromTwoDigits();

            var stringList = new List<string>();
            var reversedStrings = new List<string>();

            foreach (var product in productList)
            {
                var str = product.ToString();
                stringList.Add(str);

                var charArray = str.ToCharArray();
                Array.Reverse(charArray);
                var revString = new String(charArray);
                reversedStrings.Add(revString);
            }

            for (int i = stringList.Count - 1; i >= 0; i--)
            {
                if (stringList[i] == reversedStrings[i])
                    return Int32.Parse(stringList[i]);
            }

            return 0;
        }

        public static List<int> GenerateProductsFromThreeDigits()
        {
            // find all the products
            var numberList = new List<int>() { 1, 1, 1 };

            var productList = new List<int>();

            while (numberList[2] != 9)
            {
                var product = numberList[0] * numberList[1] * numberList[2];

                if (!productList.Contains(product))
                    productList.Add(product);

                numberList[0]++;

                if (numberList[0] > 9)
                {
                    numberList[0] = 1;
                    numberList[1]++;

                    if (numberList[1] > 9)
                    {
                        numberList[1] = 1;
                        numberList[2]++;

                        if (numberList[2] > 9)
                            numberList[2] = 9;
                    }
                }
            }

            return productList;
        }

        public static List<int> GenerateProductsFromTwoDigits()
        {
            var numberList = new List<int>() { 100, 100 };

            var productList = new List<int>();

            while (numberList[1] < 1000)
            {
                var product = numberList[0] * numberList[1];

                if (!productList.Contains(product))
                    productList.Add(product);

                numberList[0]++;

                if (numberList[0] > 999)
                {
                    numberList[0] = 100;
                    numberList[1]++;
                }
            }

            return productList;
        }
    }

    public class LargestPalindromeV2
    {
        private List<int> _numbers;

        public LargestPalindromeV2(int numOfDigits)
        {
            _numbers = GenerateNumberList(numOfDigits);
        }

        public int FindLargestPalendromeProduct()
        {
            var palindromeList = GeneratePalindromeList(_numbers);
            var largest = GetLargestIntFromIntList(palindromeList);

            return largest;
        }

        private List<int> GeneratePalindromeList(List<int> numberList)
        {
            var palindromeList = new List<int>();

            for (int i = numberList[0]; i > 0; i--)
            {
                for (int j = numberList[1]; j > 0; j--)
                {
                    int product = i * j;
                    string productStr = product.ToString();

                    var charArray = productStr.ToCharArray();
                    Array.Reverse(charArray);
                    var revStr = new String(charArray);


                    if (productStr == revStr)
                        palindromeList.Add(product);
                }
            }

            return palindromeList;
        }

        private int GetLargestIntFromIntList(List<int> intList)
        {
            var largest = 0;

            foreach (var number in intList)
            {
                if (number > largest)
                    largest = number;
            }

            return largest;
        }

        private List<int> GenerateNumberList(int numOfDigits)
        {
            List<int> startingDigits;
            switch (numOfDigits)
            {
                case 2:
                    startingDigits = new List<int>() { 99, 99 };
                    break;
                case 3:
                    startingDigits = new List<int>() { 999, 999 };
                    break;
                default:
                    startingDigits = null;
                    break;
            }

            return startingDigits;
        }

        ~LargestPalindromeV2()
        {
            Console.WriteLine("I am being destructed.");
        }
    }
}
