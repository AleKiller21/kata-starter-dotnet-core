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

            var numbers = input.Split(",");
            if (numbers.Length == 1)
            {
                return int.Parse(numbers.First());
            }
            
            return int.Parse(numbers.First()) + int.Parse(numbers.Last());
        }
    }
}