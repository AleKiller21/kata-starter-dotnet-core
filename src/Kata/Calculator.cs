using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string input = "")
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var separators = new [] {",", "\n"};

            var userInput = input;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split("\n");

                separators = new[] {parts
                    .First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Replace("]", "")
                };
                userInput = parts.Last();
            }
            
            var numbers = userInput
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray()
                .Where(number => number <= 1000);

            var negatives = numbers.Where(number => number < 0).ToArray();
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();
        }
    }
}