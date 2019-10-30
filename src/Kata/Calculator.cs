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

            var delimiters = new []{",", "\n"};
            var userInput = input;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split("\n");

                delimiters = new[]
                {
                    parts
                        .First()
                        .Replace("//", "")
                        .Replace("[", "")
                        .Replace("]", "")
                };

                userInput = parts.Last();
            }
            
            var numbers = userInput.Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n < 1001)
                .ToArray();
            
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();
        }
    }
}