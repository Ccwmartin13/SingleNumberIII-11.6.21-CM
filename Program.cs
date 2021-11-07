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

            try
            {
                List<int> listNumbers = ConvertUserInputToIntList(inputNumbers);
                
                int[] uniqueNumbers = SingleNumber(listNumbers.ToArray());

                DisplayUniqueNumbers(uniqueNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string[] GetUserInput()
        {
            Console.WriteLine("Please enter a few comma-separated numbers. You are allowed to repeat the same number.");
            string userInput = Console.ReadLine();

            string[] numbers = userInput.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            return numbers;
        }

        private static List<int> ConvertUserInputToIntList(string[] numbers)
        {
            List<int> listNumbers = new List<int>();
            
            TryConvertNumbers(numbers, listNumbers);

            return listNumbers;
        }

        private static void TryConvertNumbers(string[] numbers, List<int> listNumbers)
        {
            foreach (string number in numbers)
            {
                if (int.TryParse(number, out int actualNumber))
                {
                    listNumbers.Add(actualNumber);
                }
                else
                {
                    throw new Exception($"\r\nAttempted conversion of '{number ?? "<null>"}' failed. \r\nPlease try again with only numbers.");
                }
            }
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
            Console.WriteLine("\r\nThe non-repeated number(s) are: ");

            foreach (var number in uniqueNumbers)
                Console.WriteLine(number);

            Console.ReadKey();
        }
    }
}
