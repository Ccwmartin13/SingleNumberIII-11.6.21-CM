using System;
using System.Collections.Generic;
using System.Linq;

namespace TestApp1_11._6._21_CM
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Please enter a few comma-separated numbers. You are allowed to repeat the same number.");
            //string userInput = Console.ReadLine();
            //Console.WriteLine("The numbers input are: " + userInput);

            //string[] numbers = userInput.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            List<int> listNumbers = new List<int>();

            listNumbers.Add(1);
            listNumbers.Add(2);
            listNumbers.Add(3);
            listNumbers.Add(4);
            listNumbers.Add(2);
            listNumbers.Add(3);
            listNumbers.Add(4);
            listNumbers.Add(5);

            //foreach (string number in numbers)
            //{ 

            //    if (int.TryParse(number, out int actualNumber))
            //    {
            //        listNumbers.Add(actualNumber);
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Attempted conversion of '{number ?? "<null>"}' failed.");
            //    }
            //}

            int[] finalNumbers;
            finalNumbers = SingleNumber(listNumbers.ToArray());
            
            Console.WriteLine("The non-repeated numbers are: ");

            foreach (int num in finalNumbers)
            {
                Console.WriteLine(num);
            }

            Console.ReadKey();
        }
        public static int[] SingleNumber(int[] nums)
        {
            List<int> nonRepeatedNumbers = new List<int>();

            foreach (int num in nums.Distinct())
            {
                nonRepeatedNumbers.Add(num);
            }

            return nonRepeatedNumbers.ToArray();
        }
    }
}
