using System;
using System.Collections.Generic;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}. 
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>Array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Step 1: Create an array of size 'length' to hold the multiples.
        // The size of the array is determined by the 'length' parameter.
        double[] multiples = new double[length];

        // Step 2: Loop from 0 to 'length - 1'. For each iteration, calculate the next multiple.
        // We calculate the multiple by multiplying the 'number' by (i + 1).
        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1); // Store the current multiple at index 'i'.
        }

        // Step 3: Return the array containing all the multiples.
        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'. For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}. The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Step 1: Check if the list is empty or if the amount is 0.
        // If the list is empty or the rotation amount is zero, there's no need to rotate.
        if (data.Count == 0 || amount == 0)
        {
            return; // No rotation needed.
        }

        // Step 2: Handle cases where the rotation amount is larger than the list size.
        // Use modulo (%) to reduce the amount to a number less than the size of the list.
        amount = amount % data.Count;

        // Step 3: Split the list into two parts:
        // - The last 'amount' elements (these will be moved to the front)
        List<int> lastPart = data.GetRange(data.Count - amount, amount);
        
        // - The remaining elements (these will follow the last part)
        List<int> firstPart = data.GetRange(0, data.Count - amount);

        // Step 4: Clear the original list to prepare for adding the rotated parts.
        data.Clear();

        // Step 5: Add the last part first (these elements should come to the front).
        data.AddRange(lastPart);

        // Step 6: Add the first part after the last part.
        data.AddRange(firstPart);

        // The list is now rotated in place.
    }

    // Optional: Test the functions
    public static void Run()
    {
        // Test MultiplesOf
        double[] multiples = MultiplesOf(7, 5);
        Console.WriteLine("MultiplesOf(7,5): " + string.Join(", ", multiples));

        // Test RotateListRight
        List<int> myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(myList, 3); // Rotate by 3
        Console.WriteLine("RotateListRight by 3: " + string.Join(", ", myList));

        myList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(myList, 5); // Rotate by 5
        Console.WriteLine("RotateListRight by 5: " + string.Join(", ", myList));
    }
}