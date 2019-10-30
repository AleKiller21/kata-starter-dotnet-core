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

            return int.Parse(input);
        }
    }
}