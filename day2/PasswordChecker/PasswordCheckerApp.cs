using System;
using System.IO;

namespace PasswordChecker
{
    public class PasswordCheckerApp
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines(@"..\..\..\input.txt");
            Console.WriteLine("There are {0} correct passwords in the input", CountCorrectPasswords(inputs));
            Console.WriteLine("There are {0} correct passwords in the 2 input", CountCorrectPasswords2(inputs));
        }

        public static int CountCorrectPasswords(string[] inputs)
        {
            var counter = 0;
            foreach (var input in inputs)
            {
                var pattern = GetPattern(input);
                var password = GetPassword(input);
                if (CheckPasswordMatchPattern(password, pattern))
                {
                    counter++;
                }
            }
            return counter;
        }

        public static bool CheckPasswordMatchPattern(string password, string pattern)
        {
            var countChars = 0;
            var repetitions = pattern.Substring(0, pattern.IndexOf(' '));
            var minRepetition = GetMinRange(pattern, repetitions);
            var maxRepetition = GetMaxRange(pattern, repetitions);
            var charToLookFor = GetCharToLookFor(pattern);

            foreach (var character in password.ToCharArray())
            {
                if (charToLookFor == character)
                {
                    countChars++;
                }
            }
            return (countChars >= minRepetition && countChars <= maxRepetition);
        }

        public static int CountCorrectPasswords2(string[] inputs)
        {
            var counter = 0;
            foreach (var input in inputs)
            {
                var pattern = GetPattern(input);
                var password = GetPassword(input);
                if (CheckPasswordMatch2Pattern(password, pattern))
                {
                    counter++;
                }
            }
            return counter;
        }

        public static bool CheckPasswordMatch2Pattern(string password, string pattern)
        {
            var range = pattern.Substring(0, pattern.IndexOf(' '));
            var minRange = GetMinRange(pattern, range);
            var maxRange = GetMaxRange(pattern, range);
            var charToLookFor = GetCharToLookFor(pattern);

            if (password[minRange - 1] == charToLookFor &&
                password[maxRange - 1] == charToLookFor)
                return false;
            else if (password[minRange - 1] == charToLookFor ||
                password[maxRange - 1] == charToLookFor)
                return true;
            else
                return false;
        }

        private static string GetPattern(string input)
        {
            return input.Substring(0, input.IndexOf(':')).Trim();
        }

        private static string GetPassword(string input)
        {
            return input.Substring(input.IndexOf(':')+1).Trim();
        }

        private static char GetCharToLookFor(string pattern)
        {
            return char.Parse(pattern.Substring(pattern.IndexOf(' ') + 1));
        }

        private static int GetMaxRange(string pattern, string repetitions)
        {
            return int.Parse(repetitions.Substring(pattern.IndexOf('-') + 1));
        }

        private static int GetMinRange(string pattern, string repetitions)
        {
            return int.Parse(repetitions.Substring(0, pattern.IndexOf('-')));
        }
    }
}
