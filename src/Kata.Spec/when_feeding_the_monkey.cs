using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;
        
        Establish context = () => 
            _systemUnderTest = new Monkey();

        Because of = () => 
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }


    public class when_user_input_is_empty
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum(); };

        It should_return_zero = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_one_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("3"); };

        It should_return_the_same_number = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("1,2"); };

        It should_return_the_sum_of_those_numbers = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    };

    public class when_user_input_is_unknown_amount_of_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("1,2,3"); };

        It should_do_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_multiple_numbers_with_new_line_and_comma_delimiters
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("1\n2,3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_multiple_numbers_with_a_custom_single_character_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("//;\n1;2"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_contains_one_negative_number
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Sum("1,-2,3")); };

        It should_throw_an_exception = () => { _result.Message.Should().Be("negatives not allowed: -2"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_user_input_contains_multiple_negative_numbers_mixed_with_positive_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        private Because of = () => { _result = Catch.Exception(() => _systemUnderTest.Sum("1,-2,-3,-4")); };

        It should_throw_an_exception_ = () => { _result.Message.Should().Be("negatives not allowed: -2, -3, -4"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_user_input_contains_numbers_larger_than_1000
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("2,1001"); };

        It should_return_the_sum_of_numbers_less_than_1001 = () => { _result.Should().Be(2); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_user_input_is_multiple_numbers_with_a_custom_multi_character_delimiter
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("//[***]\n1***2***3"); };

        It should_return_the_sum_of_all_numbers = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }
}


// 10. Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[***]\n1***2***3” should return 6)
// 11. Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[*][%]\n1*2%3” should return 6)
