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

            var numArray = numbers.Split(delimiters, StringSplitOptions.None).Select(int.Parse);
            return numArray.Sum();
        }
    }
}