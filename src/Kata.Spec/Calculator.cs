using System;
using System.Linq;

namespace Kata.Spec
{
    public class Calculator
    {
        public int Sum(string input = "")
        {
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }

            var delimiters = new[] {',', '\n'};
            var numbers = input;

            if (input.StartsWith("//"))
            {
                var customInput = input.Split('\n');
                delimiters = new []{customInput.First().Last()};
                numbers = customInput.Last();
            }

            var numArray = numbers.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();
            var negatives = numArray.Where(num => num < 0).ToArray();

            if (negatives.Count() == 1)
            {
                throw new Exception($"negatives not allowed: {negatives.First()}");
            }
            return numArray.Sum();
        }
    }
}