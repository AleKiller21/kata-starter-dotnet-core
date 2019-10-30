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
                };

                userInput = parts.Last();
            }
            
            var numbers = userInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();
            
            var negatives = numbers.Where(n => n < 0);
            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {negatives.First()}");
            }

            return numbers.Sum();
        }
    }
}