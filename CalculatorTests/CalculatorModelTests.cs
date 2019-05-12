using Calculator.Models;
using NUnit.Framework;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorModelTests
    {
        [Test]
        public void CalculatorModel_NoParams_InitializesCorrectly()
        {
            // Act
            var calculatorModel = new CalculatorModel();
            // Assert
            Assert.AreEqual(string.Empty, calculatorModel.LeftOperand);
            Assert.AreEqual(string.Empty, calculatorModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorModel.Operation);
            Assert.AreEqual(string.Empty, calculatorModel.Result);
        }

        [Test]
        public void CalculatorModel_WithParams_InitializesCorrectly()
        {
            // Act
            var calculatorModel = new CalculatorModel("321", "789", "+");
            // Assert
            Assert.AreEqual("321", calculatorModel.LeftOperand);
            Assert.AreEqual("789", calculatorModel.RightOperand);
            Assert.AreEqual("+", calculatorModel.Operation);
            Assert.AreEqual(string.Empty, calculatorModel.Result);
        }

        [Test]
        [TestCase("321", "654", "+", "975")]
        [TestCase("741", "951", "-", "-210")]
        [TestCase("3", "42", "*", "126")]
        [TestCase("256", "8", "/", "32")]
        public void CalculateResult_WhenValidParametersPassed_ThenResultIsCalculatedCorrectly(string leftOperand, string rightOperand, string operation, string expectedResult)
        {
            // Arrange
            var calculatorModel = new CalculatorModel(leftOperand, rightOperand, operation);
            // Act
            calculatorModel.CalculateResult();
            // Assert
            Assert.AreEqual(leftOperand, calculatorModel.LeftOperand);
            Assert.AreEqual(rightOperand, calculatorModel.RightOperand);
            Assert.AreEqual(operation, calculatorModel.Operation);
            Assert.AreEqual(expectedResult, calculatorModel.Result);
        }

        [Test]
        public void CalculateResult_WhenDevisionByZero_ThenResultIsCalculationError()
        {
            // Arrange
            var calculatorModel = new CalculatorModel("12", "0", "/");
            // Act
            calculatorModel.CalculateResult();
            // Assert
            Assert.AreEqual(string.Empty, calculatorModel.LeftOperand);
            Assert.AreEqual(string.Empty, calculatorModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorModel.Operation);
            Assert.AreEqual("Calculation Error", calculatorModel.Result);
        }

        [Test]
        [TestCase("2147483647", "1", "+")]
        [TestCase("-2147483648", "1", "-")]
        [TestCase("1073741824", "2", "*")]
        [TestCase("2147483648", "2", "/")]
        public void CalculateResult_WhenInt32IsExceeded_ThenResultIsCalculationError(string leftOperand, string rightOperand, string operation)
        {
            // Arrange
            var calculatorModel = new CalculatorModel(leftOperand, rightOperand, operation);
            // Act
            calculatorModel.CalculateResult();
            // Assert
            Assert.AreEqual(string.Empty, calculatorModel.LeftOperand);
            Assert.AreEqual(string.Empty, calculatorModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorModel.Operation);
            Assert.AreEqual("Calculation Error", calculatorModel.Result);
        }

        [Test]
        [TestCase("321", "-321")]
        [TestCase("-852", "852")]
        public void ChangeLeftOperandSign_ChangesLeftOperandSignCorrectly(string leftOperand, string expectedValue)
        {
            // Arrange
            var calculatorModel = new CalculatorModel();
            calculatorModel.LeftOperand = leftOperand;
            // Act
            calculatorModel.ChangeLeftOperandSign();
            // Assert
            Assert.AreEqual(expectedValue, calculatorModel.LeftOperand);
        }

        [Test]
        [TestCase("321", "-321")]
        [TestCase("-852", "852")]
        public void ChangeLeftOperandSign_ChangesRighOperandSignCorrectly(string rightOperand, string expectedValue)
        {
            // Arrange
            var calculatorModel = new CalculatorModel();
            calculatorModel.RightOperand = rightOperand;
            // Act
            calculatorModel.ChangeRightOperandSign();
            // Assert
            Assert.AreEqual(expectedValue, calculatorModel.RightOperand);
        }
    }
}