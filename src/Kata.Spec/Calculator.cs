using System;
using System.Linq;

namespace Kata.Spec
{
    public class Calculator
    {
        public int Sum(string input = "")
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new[] {",", "\n"};
            var numbers = input;

            if (input.StartsWith("//"))
            {
                var customInput = input.Split('\n');
                var customDelimiterSection = customInput.First();
                delimiters = new[]
                {
                    customDelimiterSection
                        .Replace("//", "")
                        .Replace("[", "")
                        .Replace("]", "")
                };
                numbers = customInput.Last();
            }

            var numArray = numbers
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n < 1001)
                .ToArray();
            var negatives = numArray.Where(num => num < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }
            return numArray.Sum();
        }
    }
}