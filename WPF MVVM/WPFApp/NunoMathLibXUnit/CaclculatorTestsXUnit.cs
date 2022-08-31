using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace NunoMathLibXUnit
{
    public class CaclculatorTestsXUnit
    {
        [Fact]
        public void AddShouldReturnSumOfValues()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(2, 3);
            Assert.Equal(5, result);
        }


        [Theory]
        [InlineData(5,2,3)]
        [InlineData(10,4,6)]
        [InlineData(2,5,-3)]
        public void AddShouldReturnSumOfValuesTheory(int expectedvalue,int val1, int val2)
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(val1, val2);
            Assert.Equal(expectedvalue, result);
        }

    }
}
