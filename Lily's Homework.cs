using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'lilysHomework' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int lilysHomework(List<int> arr)
    {
         int n = arr.Count;
        int swapsAsc = CountSwaps(new List<int>(arr), arr.OrderBy(x => x).ToList());
        int swapsDesc = CountSwaps(new List<int>(arr), arr.OrderByDescending(x => x).ToList());
        return Math.Min(swapsAsc, swapsDesc);
    }

    private static int CountSwaps(List<int> arr, List<int> sorted)
    {
        int swaps = 0;
        Dictionary<int, int> indexMap = new Dictionary<int, int>();

        for (int i = 0; i < arr.Count; i++)
            indexMap[arr[i]] = i;

        for (int i = 0; i < arr.Count; i++)
        {
            if (arr[i] != sorted[i])
            {
                swaps++;

                int swapIdx = indexMap[sorted[i]];

                // Update the index map
                indexMap[arr[i]] = swapIdx;
                indexMap[arr[swapIdx]] = i;

                // Swap in array
                int temp = arr[i];
                arr[i] = arr[swapIdx];
                arr[swapIdx] = temp;
            }
        }

        return swaps;
    }

    }


class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.lilysHomework(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
