using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddShouldReturnSumOfValues()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(2, 3);
            Assert.AreEqual(5, result);
        }
    }
}