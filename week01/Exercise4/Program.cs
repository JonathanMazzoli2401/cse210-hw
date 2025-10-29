using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        List<int> numbers = new List<int>();

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        float average = (float)sum / numbers.Count;

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        int smallesPositive = int.MaxValue;
        foreach (int number in numbers)
        {
            if (number > 0 && number < smallesPositive)
            {
                smallesPositive = number;
            }
        }

        numbers.Sort();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");

        if (smallesPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallesPositive}");
        }
        else
        {
            Console.WriteLine("There were no positive numbers in the list.");
        }

        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}