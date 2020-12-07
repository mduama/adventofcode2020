using System;
using System.Collections.Generic;
using System.IO;

namespace Tobogan
{
    public class Program
    {
        static void Main(string[] args)
        {
            ToboganApp app = new ToboganApp();
            int numTrees1r1d = app.CountTrees("../../../input.txt", 1, 1);
            Console.WriteLine("The number of trees for 1r 1d is {0}", numTrees1r1d);
            int numTrees3r1d = app.CountTrees("../../../input.txt", 3, 1);
            Console.WriteLine("The number of trees for 3r 1d is {0}", numTrees3r1d);
            int numTrees5r1d = app.CountTrees("../../../input.txt", 5, 1);
            Console.WriteLine("The number of trees for 5r 1d is {0}", numTrees5r1d);
            int numTrees7r1d = app.CountTrees("../../../input.txt", 7, 1);
            Console.WriteLine("The number of trees for 7r 1d is {0}", numTrees7r1d);
            int numTrees1r2d = app.CountTrees("../../../input.txt", 1, 2);
            Console.WriteLine("The number of trees for 1r 2d is {0}", numTrees1r2d);
            double mult = numTrees1r1d * numTrees3r1d * numTrees5r1d * numTrees7r1d * numTrees1r2d;
            Console.WriteLine("The multiplication is {0}", mult); // 7540141059
        }
    }

    public class ToboganApp
    {
        private readonly char dot = '.';
        private readonly char dash = '#';
        public static readonly int open = 0;
        public static readonly int tree = 1;

        public int[][] ConvertedInputs { get; set; }

        public int CountTrees(string filePath, int right, int down)
        {
            ConvertAllInputsToMap(File.ReadAllLines(filePath));
            var treesCounter = 0;
            var location = 0;
            var currentPosition = new int[] { 0, 0 };
            do {
                location = GetLocationItem(currentPosition);
                if (location == tree)
                {
                    treesCounter++;
                }
                Move(ref currentPosition, right, down);
            } while (location != -1);
            return treesCounter;
        }

        private static void Move(ref int[] currentPosition, int right, int down)
        {
            currentPosition[0]+= down;
            currentPosition[1]+= right;
        }

        public int GetLocationItem(int[] currentPosition)
        {
            if (currentPosition[0] >= ConvertedInputs.Length) 
            {
                return -1;
            }
            if (currentPosition[1] >= ConvertedInputs[currentPosition[0]].Length)
            {
                ExpandMap();
            }
            return ConvertedInputs[currentPosition[0]][currentPosition[1]];
        }

        private void ExpandMap()
        {
            for (int i = 0; i < ConvertedInputs.Length; i++)
            {
                var expandedMapRow = new List<int>();
                expandedMapRow.AddRange(ConvertedInputs[i]);
                expandedMapRow.AddRange(ConvertedInputs[i]);
                ConvertedInputs[i] = expandedMapRow.ToArray();
            }
        }

        public void ConvertAllInputsToMap(string[] inputs)
        {
            var convertedInputs = new int[inputs.Length][];
            var i = 0;
            foreach (var input in inputs)
            {
                convertedInputs[i++] = this.ConvertOneInputToMap(input);
            }
            ConvertedInputs = convertedInputs;
        }

        public int[] ConvertOneInputToMap(string input)
        {
            var convertedInput = new int[input.Length];
            var i = 0;
            foreach (var character in input.ToCharArray())
            {
                if (character == dot) convertedInput[i++] = open;
                if (character == dash) convertedInput[i++] = tree;
            }
            return convertedInput;
        }
    }
}
