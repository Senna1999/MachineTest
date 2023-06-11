using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senna_machinetest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the maximum limit:");
            if (!int.TryParse(Console.ReadLine(), out int limit) || limit <= 0)
            {
                Console.WriteLine("Invalid limit. Exiting the program.");
                return;
            }


            //reading integer list

            List<int> num = new List<int>();

            Console.WriteLine($"Enter the numbers (up to {limit}, enter any value):");
            try
            {
                while (num.Count < limit)
                {
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        num.Add(number);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Stopping input.");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during input: {ex.Message}");
                return;
            }

            Console.WriteLine("Entered numbers:");
            foreach (int number in num)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();

            try
            {
                int maxSum = contiguous_arr(num);
                Console.WriteLine("Maximum sum of contiguous subarray: " + maxSum);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during calculation: {ex.Message}");
            }
            Console.Read();
        }
        //function for finding maximum sum
        static int contiguous_arr(List<int> num)
        {
            if (num.Count == 0)
                Console.WriteLine("The list cannot be empty.");

            int max = num[0];
            int curr = num[0];

            for (int i = 1; i < num.Count; i++)
            {
                curr = Math.Max(num[i], curr + num[i]);
                max = Math.Max(max, curr);
            }

            return max;
        }
    }
}
