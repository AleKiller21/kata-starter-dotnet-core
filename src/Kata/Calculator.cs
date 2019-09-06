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
            
            var delimiters = new[] {",", "\n"};
            var newInput = userInput;

            if (userInput.StartsWith("//"))
            {
                var parsedInput = userInput.Split('\n');
                var delimiterSection = parsedInput.First();
                var delimiter = delimiterSection.Replace("//", "");
                delimiters = new[] {delimiter};
                newInput = parsedInput.Last();
            }
            
            var numbers = newInput
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n <= 1000)
                .ToArray();
            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();
        }
    }
}