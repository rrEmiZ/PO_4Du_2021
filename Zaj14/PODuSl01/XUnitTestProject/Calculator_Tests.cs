using PODuSl01;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class Calculator_Tests
    {
        [Fact]
        public void Test1()
        {
            Assert.True(true);
        }

        [Fact]
        public void Add_Adding1And2_Returns3()
        {
            const int a = 1;
            const int b = 2;
            const int resultExpected = 3;
            var calc = new Calculator();

            int result = calc.Add(a, b);

            Assert.Equal(resultExpected, result);
        }

        [Fact]
        public void IsEven_IfNumberIs1_ReturnFalse()
        {
            var calc = new Calculator();

            bool result = calc.IsEven(1);

            Assert.False(result, "1 is not even");
        }

        [Fact]
        public void IsEven_IfNumberIs2_ReturnTrue()
        {
            var calc = new Calculator();

            bool result = calc.IsEven(2);

            Assert.True(result, "2 is  even");
        }

        [Theory]
        [InlineData(545312230)]
        [InlineData(0)]
        [InlineData(15464)]
        public void IsEven_BigNumbers(int number)
        {
            var calc = new Calculator();

            bool result = calc.IsEven(number);

            Assert.True(result);
        }

    }
}
