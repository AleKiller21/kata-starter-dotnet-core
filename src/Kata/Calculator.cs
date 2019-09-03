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

            var delimiters = new []{",", "\n"};
            var input = userInput;

            if (userInput.StartsWith("//"))
            {
                var parts = input.Split('\n');
                delimiters = new[] {parts.First().Replace("//", "")};
                input = parts.Last();
            }
            
            var numbers = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();
            var negatives = numbers.Where(number => number < 0).ToArray();
            if (negatives.Count() == 1)
            {
                throw new Exception($"negatives not allowed: {negatives.First()}");
            }
            return numbers.Sum();

        }
    }
}