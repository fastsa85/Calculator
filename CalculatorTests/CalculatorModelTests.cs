using Calculator.Models;
using NUnit.Framework;

namespace Tests
{
    public class CalculatorModelTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculatorModel_NoParams_InitializesCorrectly()
        {
            var calculatorModel = new CalculatorModel();

            Assert.AreEqual(string.Empty, calculatorModel.LeftOperand);
            Assert.AreEqual(string.Empty, calculatorModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorModel.Operation);
            Assert.AreEqual(string.Empty, calculatorModel.Result);
        }

        [Test]
        public void CalculatorModel_WithParams_InitializesCorrectly()
        {
            var calculatorModel = new CalculatorModel("321", "789", "+");

            Assert.AreEqual("321", calculatorModel.LeftOperand);
            Assert.AreEqual("789", calculatorModel.RightOperand);
            Assert.AreEqual("+", calculatorModel.Operation);
            Assert.AreEqual(string.Empty, calculatorModel.Result);
        }

        [Test]
        [TestCase("321", "654", "+", "975")]
        [TestCase("321", "0", "+", "321")]
        [TestCase("321", "-321", "+", "0")]
        public void CalculatorModel_AddsCorrectly(string leftOperand, string rightOperand, string operation, string expectedResult)
        {
            var calculatorModel = new CalculatorModel(leftOperand, rightOperand, operation);
            calculatorModel.CalculateResult();
            Assert.AreEqual(expectedResult, calculatorModel.Result);
        }
    }
}