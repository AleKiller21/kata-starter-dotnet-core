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

                separators = new[] {parts.First().Replace("//", "")};
                userInput = parts.Last();
            }
            
            var numbers = userInput
                .Split(separators, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();
            return numbers.Sum();
        }
    }
}