using System;

class Program
{
    static void Main()
    {
        int[] arr = new int[10];

        // Step 1: Reading all data from user in runtime
        Console.WriteLine("Enter 10 integer values:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Element {i + 1}: ");
            arr[i] = int.Parse(Console.ReadLine());
        }

        // Step 2: Find the min and max value in the array
        int minValue = arr[0];
        int maxValue = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] < minValue)
                minValue = arr[i];
            if (arr[i] > maxValue)
                maxValue = arr[i];
        }

        Console.WriteLine($"Minimum value: {minValue}");
        Console.WriteLine($"Maximum value: {maxValue}");

        // Step 3: Sort the array (Bubble sort)
        for (int i = 0; i < arr.Length - 1; i++)
        {
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j + 1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }

        Console.WriteLine("Array after sorting:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine();

        // Step 4: Search for a number in the array
        Console.Write("Which number do you want to search? ");
        int searchNumber = int.Parse(Console.ReadLine());
        bool found = false;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == searchNumber)
            {
                Console.WriteLine($"Number {searchNumber} found at index {i}");
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine($"Number {searchNumber} not found in the array.");
        }
    }
}
