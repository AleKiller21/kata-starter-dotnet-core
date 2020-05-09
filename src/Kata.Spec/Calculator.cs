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

            var numArray = input.Split(new[] {',', '\n'}, StringSplitOptions.None).Select(int.Parse);
            return numArray.Sum();
        }
    }
}