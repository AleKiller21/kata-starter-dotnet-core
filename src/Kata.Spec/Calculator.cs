namespace Kata.Spec
{
    public class Calculator
    {
        public int Sum(string number = "")
        {
            if (string.IsNullOrEmpty(number))
            {
                return 0;
            }

            return int.Parse(number);
        }
    }
}