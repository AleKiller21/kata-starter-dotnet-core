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
            var numberSection = userInput;
            
            if (userInput.StartsWith("//"))
            {
                var parsedInput = userInput.Split("\n");
                var delimiterSection = parsedInput[0];
                numberSection = parsedInput[1];
                delimiters = new[] {delimiterSection.Replace("//", "")};
            }

            var numbers = numberSection.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}