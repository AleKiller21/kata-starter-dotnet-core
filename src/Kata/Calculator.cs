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
            var input = userInput;

            if (userInput.StartsWith("//"))
            {
                var parsedInput = userInput.Split('\n');
                delimiters = new[] {parsedInput.First().Replace("//", "")};
                input = parsedInput.Last();
            }

            var numbers = input
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            
            return numbers.Sum();
        }
    }
}