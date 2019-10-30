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

            return numbers.Sum();
        }
    }
}