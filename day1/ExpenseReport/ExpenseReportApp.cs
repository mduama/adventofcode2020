using System;
using System.IO;
using System.Linq;

namespace ExpenseReport
{
    public class ExpenseReportApp
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines(@"..\..\..\input.txt")
                        .Select(y => int.Parse(y))
                        .ToArray();
            Console.WriteLine($"The expense report with 2 numbers result is {CalculateExpenseReportWith2Numbers(inputs)}");
            Console.WriteLine($"The expense report with 3 numbers result is {CalculateExpenseReportWith3Numbers(inputs)}");
        }

        static public int CalculateExpenseReportWith2Numbers(int[] inputs)
        {
            int[] entries2020 = Calculate2EntriesThatSum2020(inputs);
            return MultiplyEntries2020(entries2020);
        }

        private static int[] Calculate2EntriesThatSum2020(int[] inputs)
        {
            var result = new int[2];
            var found = false;
            for (var i = 0; i < inputs.Length; i++)
            {
                for (var j = i + 1; j < inputs.Length; j++)
                {
                    if (inputs[i] + inputs[j] == 2020)
                    {
                        result[0] = inputs[i];
                        result[1] = inputs[j];
                        Console.WriteLine($"The sums are {result[0]} and {result[1]}");
                        found = true;
                    }
                    if (found) break;
                }
                if (found) break;
            }
            return result;
        }

        static public int CalculateExpenseReportWith3Numbers(int[] inputs)
        {
            int[] entries2020 = Calculate3EntriesThatSum2020(inputs);
            return MultiplyEntries2020(entries2020);
        }

        private static int[] Calculate3EntriesThatSum2020(int[] inputs)
        {
            var result = new int[3];
            var found = false;
            for (var i = 0; i < inputs.Length; i++)
            {
                for (var j = i + 1; j < inputs.Length; j++)
                {
                    for (var k = j + 1; k < inputs.Length; k++)
                    {
                        if (inputs[i] + inputs[j] + inputs[k] == 2020)
                        {
                            result[0] = inputs[i];
                            result[1] = inputs[j];
                            result[2] = inputs[k];
                            Console.WriteLine($"The sums are {result[0]}, {result[1]} and {result[2]}");
                            found = true;
                        }
                        if (found) break;
                    }
                    if (found) break;
                }
                if (found) break;
            }
            return result;
        }

        private static int MultiplyEntries2020(int[] entries2020)
        {
            var result = 1;
            foreach (var entry in entries2020)
            {
                result *= entry;
            }
            return result;
        }
    }
}
