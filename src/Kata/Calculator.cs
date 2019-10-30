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

            var numbers = input.Split(new []{",", "\n"}, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}