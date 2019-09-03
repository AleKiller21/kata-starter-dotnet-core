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

            var numbers = userInput.Split(',');
            if (numbers.Length == 1)
            {
                return int.Parse(numbers[0]);
            }

            var nums = numbers.Select(int.Parse).ToArray();
            return nums[0] + nums[1];

        }
    }
}