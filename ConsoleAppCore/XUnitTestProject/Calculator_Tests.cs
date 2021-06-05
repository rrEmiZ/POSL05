using ConsoleAppCore;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class Calculator_Tests
    {
        private readonly Calculator _calc;

        public Calculator_Tests()
        {
            _calc = new Calculator();
        }


        [Fact]
        public void Test1()
        {
            Assert.False(false);
        }

        [Fact]
        public void Add_1And2_Equals3()
        {
          //  var calc = new Calculator();
            const int resultExpected = 3;

            var result = _calc.Add(1, 2);

            Assert.Equal(result, resultExpected);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(5, 6, 11)]
        [InlineData(2, 1, 3)]
        public void Add_APlusB_EqualsResult(int a, int b, int result)
        {
         //   var calc = new Calculator();

            var resultCalc = _calc.Add(a, b);

            Assert.Equal(resultCalc, result);
        }

        [Fact]
        public void IsEven_ForNumber2_ReturnsTrue()
        {
            bool result = _calc.IsEven(2);

            Assert.True(result);
        }

        [Fact]
        public void IsEven_ForNumber1_ReturnsFalse()
        {
            bool result = _calc.IsEven(1);
            Assert.False(result);
        }

    }
}
