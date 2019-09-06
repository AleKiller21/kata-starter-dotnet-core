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
            
            var numbers = newInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}