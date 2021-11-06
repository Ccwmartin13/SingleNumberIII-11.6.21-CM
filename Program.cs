using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp1_11._6._21_CM
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> listNumbers = new List<int>();

            Console.WriteLine("Please enter a few comma-separated numbers. You are allowed to repeat the same number.");
            string userInput = Console.ReadLine();
            Console.WriteLine("The numbers input are: " + userInput);

            string[] numbers = userInput.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

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

            int[] finalNumbers = SingleNumber(listNumbers.ToArray());
            
            Console.WriteLine("The non-repeated numbers are: ");

            foreach (var num in finalNumbers)
                Console.WriteLine(num);

            Console.ReadKey();
        }
        public static int[] SingleNumber(int[] nums)
        {
            IEnumerable<int> uniqueNumbers = nums
                .GroupBy(i => i)
                .Where(g => g.Count() == 1)
                .Select(g => g.Key);

            return uniqueNumbers.ToArray();
        }
    }
}
