using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp1_11._6._21_CM
{
    class Program
    {
        public static void Main(string[] args)
        {
            string[] inputNumbers = GetUserInput();

            int[] uniqueNumbers = ConvertUserInputToIntArray(inputNumbers);

            DisplayUniqueNumbers(uniqueNumbers);
        }

        private static string[] GetUserInput()
        {
            Console.WriteLine("Please enter a few comma-separated numbers. You are allowed to repeat the same number.");
            string userInput = Console.ReadLine();

            string[] numbers = userInput.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return numbers;
        }

        private static int[] ConvertUserInputToIntArray(string[] numbers)
        {
            List<int> listNumbers = new List<int>();

            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int actualNumber))
                {
                    listNumbers.Add(actualNumber);
                }
                else
                {
                    Console.WriteLine($"Attempted conversion of '{number ?? "<null>"}' failed.");
                }
            }

            int[] uniqueNumbers = SingleNumber(listNumbers.ToArray());

            return uniqueNumbers;
        }

        private static int[] SingleNumber(int[] nums)
        {
            IEnumerable<int> uniqueNumbers = nums
                .GroupBy(i => i)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key);

            return uniqueNumbers.ToArray();
        }

        private static void DisplayUniqueNumbers(int[] uniqueNumbers)
        {
            Console.WriteLine("The non-repeated numbers are: ");

            foreach (var number in uniqueNumbers)
                Console.WriteLine(number);

            Console.ReadKey();
        }
    }
}
