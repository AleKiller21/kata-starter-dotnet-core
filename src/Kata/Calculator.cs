using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput = "")
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return 0;
            }
            
            var newInput = GetInput(userInput);

            var delimiters = GetDelimiters(userInput);
            
            var numbers = ParseNumbers(newInput, delimiters);
            
            ValidateNegatives(numbers);

            return numbers.Sum();
        }

        static string GetInput(string userInput)
        {
            if (HasCustomDelimiter(userInput))
            {
                var parsedInput = GetCustomDelimiterParts(userInput);
                return parsedInput.Last();
            }

            return userInput;
        }

        static string[] GetCustomDelimiterParts(string userInput)
        {
            return userInput.Split('\n');
        }

        static bool HasCustomDelimiter(string userInput)
        {
            return userInput.StartsWith("//");
        }

        static string[] GetDelimiters(string userInput)
        {
            var delimiters = new[] {",", "\n"};
            if (HasCustomDelimiter(userInput))
            {
                var delimiter = GetCustomDelimiterParts(userInput)
                    .First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Split("]");
                delimiters = delimiter;
            }

            return delimiters;
        }

        static int[] ParseNumbers(string input, string[] delimiters)
        {
            var numbers = input
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n <= 1000)
                .ToArray();
            return numbers;
        }

        static void ValidateNegatives(int[] numbers)
        {
            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
        }
    }
}