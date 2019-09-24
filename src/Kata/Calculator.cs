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
            var values = userInput;
            if (userInput.StartsWith("//"))
            {
                var parsedInput = userInput.Split('\n');
                var delimiterSection = parsedInput.First();
                values = parsedInput.Last();
                var delimiter = delimiterSection.Replace("//", "");
                delimiters = new[] {delimiter};
            }

            var numbers = values
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            return numbers.Sum();
        }
    }
}