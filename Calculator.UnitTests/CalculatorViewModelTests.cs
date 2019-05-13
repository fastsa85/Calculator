using NUnit.Framework;
using Calculator.Models;
using Calculator.ViewModels;
using Moq;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorViewModelTests
    {
        [Test]
        public void CalculatorViewModel_NoParams_InitializesCorrectly()
        {
            // Act
            var calculatorViewModel = new CalculatorViewModel();
            //Assert
            Assert.AreEqual("0", calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.LeftOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.LeftOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        #region Digit Buttons

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenNothingIsEntered_ThenDigitButtonUpdatesLeftOperandAndDisplay()
        {
            var button = "2";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = string.Empty;
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = string.Empty;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(button, calculatorViewModel.LeftOperand);
            Assert.AreEqual(button, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenLeftOperandIsEnteredAndOperationIsNotEntered_ThenDigitButtonUpdatesLeftOperandAndDisplay()
        {
            var leftOperand = "12";
            var button = "3";
            var updatedLeftOperand = "123";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = string.Empty;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(updatedLeftOperand, calculatorViewModel.LeftOperand);
            Assert.AreEqual(updatedLeftOperand, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenLeftOperandIsEnteredAndOperationIsEnteredAndRightOperandIsNotEntered_ThenDigitButtonUpdatesRightOperandAndDisplay()
        {
            var leftOperand = "12";
            var operation = "/";
            var button = "7";
            var expectedDisplay = leftOperand + operation + button;
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = operation;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperand, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(button, calculatorViewModel.RightOperand);
            Assert.AreEqual(operation, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenLeftOperandIsEnteredAndOperationIsEnteredAndRightOperandIsEntered_ThenDigitButtonUpdatesRightOperandAndDisplay()
        {
            var leftOperand = "12";
            var rightOperand = "6";
            var operation = "+";
            var button = "8";
            var expectedRightOperand = "68";
            var expectedDisplay = leftOperand + operation + expectedRightOperand;
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperand;
            mockCalcModel.Object.Operation = operation;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperand, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(expectedRightOperand, calculatorViewModel.RightOperand);
            Assert.AreEqual(operation, calculatorViewModel.Operation);
        }
        #endregion

        #region Operation Buttons

        [Test]
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void CalculatorViewModel_OperationButtonPress_WhenLeftOperandIsNotEntered_ThenOperationButtonCanNotBePressed(string button)
        {
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = string.Empty;
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = string.Empty;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.OperationButtonPress(button);
            //Assert
            Assert.AreEqual(string.Empty, calculatorViewModel.LeftOperand);
            Assert.AreEqual("0", calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void CalculatorViewModel_OperationButtonPress_WhenLeftOperandIsEntered_ThenOperationButtonCanBePressed(string button)
        {
            var leftOperand = "77";
            var expectedDisplay = "77" + button;
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = string.Empty;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.OperationButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperand, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(button, calculatorViewModel.Operation);
        }

        [Test]
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void CalculatorViewModel_OperationButtonPress_WhenLeftOperandIsEnteredAndOperationIsEntered_ThenOperationButtonUpdatesOperationAndDisplay(string button)
        {
            var leftOperand = "20";
            var operationBeforePress = "+";
            var expectedDisplay = "20" + button;
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = operationBeforePress;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.OperationButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperand, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(button, calculatorViewModel.Operation);
        }

        [Test]
        [TestCase("+")]
        [TestCase("-")]
        [TestCase("*")]
        [TestCase("/")]
        public void CalculatorViewModel_OperationButtonPress_WhenLeftOperandIsEnteredAndOperationIsEnteredAndRightOperandIsEntered_ThenResultIsCalculatedAndDisplayed(string button)
        {
            var leftOperand = "21";
            var operationBeforePress = "+";
            var rightOperand = "6";
            var expectedDisplay = "27" + button;
            var leftOperandAfterPress = "27";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperand;
            mockCalcModel.Object.Operation = operationBeforePress;
            mockCalcModel.Setup(c => c.Result).Returns("27");
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.OperationButtonPress(button);
            //Assert
            mockCalcModel.Verify(x => x.CalculateResult(), Times.Once);
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(button, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_OperationButtonPress_WhenEqualIsPressed_ResultIsCalculatedAndDisplayed()
        {
            var leftOperand = "12";
            var operation = "+";
            var rightOperandBeforePress = "7";
            var button = "=";
            var expectedDisplay = "29";
            var leftOperandAfterPress = "29";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperandBeforePress;
            mockCalcModel.Object.Operation = operation;
            mockCalcModel.Setup(c => c.Result).Returns("29");
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.OperationButtonPress(button);
            //Assert
            mockCalcModel.Verify(x => x.CalculateResult(), Times.Once);
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }
        #endregion

        #region Positive/Negative Button

        [Test]
        public void CalculatorViewModel_PositiveNegativeButtonPress_WhenLeftOperandIsEntered_ThenChangeLeftOperandSignIsCalled()
        {
            var button = "+/-";
            var expectedDisplay = "-12";
            var leftOperandAfterPress = "-12";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.RightOperand = string.Empty;
            mockCalcModel.Object.Operation = string.Empty;
            mockCalcModel.Setup(c => c.LeftOperand).Returns("-12");
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.PositiveNegativeButtonPress(button);
            //Assert
            mockCalcModel.Verify(x => x.ChangeLeftOperandSign(), Times.Once);
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_PositiveNegativeButtonPress_WhenRightOperandIsEntered_ThenChangeRightOperandSignIsCalled()
        {
            var button = "+/-";
            var operation = "*";
            var leftOperandAfterPress = "12";
            var rightOperandAfterPress = "-8";
            var expectedDisplay = "12*-8";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.Operation = operation;
            mockCalcModel.Setup(c => c.LeftOperand).Returns("12");
            mockCalcModel.Setup(c => c.RightOperand).Returns("-8");
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.PositiveNegativeButtonPress(button);
            //Assert
            mockCalcModel.Verify(x => x.ChangeRightOperandSign(), Times.Once);
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(rightOperandAfterPress, calculatorViewModel.RightOperand);
            Assert.AreEqual(operation, calculatorViewModel.Operation);
        }
        #endregion

        #region Clear and Backspace Buttons

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenClearIsPressed_ThenOperandsAndOperationAreResetAndZeroIsDisplay()
        {
            var leftOperand = "13";
            var operation = "+";
            var rightOperand = "7";
            var expectedDisplay = "0";
            var button = "CLEAR";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperand;
            mockCalcModel.Object.Operation = operation;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(string.Empty, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenLeftOperandIsEnteredAndBackspaceIsPressed_ThenLeftOperandIsUpdated()
        {
            var leftOperand = "23";
            var operation = string.Empty;
            var rightOperand = string.Empty;
            var expectedDisplay = "2";
            var leftOperandAfterPress = "2";
            var button = "BACKSPACE";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperand;
            mockCalcModel.Object.Operation = operation;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenOperationIsEnteredAndRightOperandIsNotEnteredAndBackspaceIsPressed_ThenOperationIsCleared()
        {
            var leftOperand = "23";
            var operation = "*";
            var rightOperand = string.Empty;
            var expectedDisplay = "23";
            var leftOperandAfterPress = "23";
            var button = "BACKSPACE";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperand;
            mockCalcModel.Object.Operation = operation;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(string.Empty, calculatorViewModel.RightOperand);
            Assert.AreEqual(string.Empty, calculatorViewModel.Operation);
        }

        [Test]
        public void CalculatorViewModel_DigitButtonPress_WhenOperationIsEnteredAndRightOperandIsEnteredAndBackspaceIsPressed_ThenRightOperandIsUpdated()
        {
            var leftOperand = "23";
            var operation = "*";
            var rightOperand = "456";
            var leftOperandAfterPress = "23";
            var rightOperandAfterPress = "45";
            var expectedDisplay = "23*45";
            var button = "BACKSPACE";
            // Arrange 
            var mockCalcModel = new Mock<ICalculatorModel>();
            mockCalcModel.SetupAllProperties();
            mockCalcModel.Object.LeftOperand = leftOperand;
            mockCalcModel.Object.RightOperand = rightOperand;
            mockCalcModel.Object.Operation = operation;
            var calculatorViewModel = new CalculatorViewModel(mockCalcModel.Object);
            // Act
            calculatorViewModel.DigitButtonPress(button);
            //Assert
            Assert.AreEqual(leftOperandAfterPress, calculatorViewModel.LeftOperand);
            Assert.AreEqual(expectedDisplay, calculatorViewModel.Display);
            Assert.AreEqual(rightOperandAfterPress, calculatorViewModel.RightOperand);
            Assert.AreEqual(operation, calculatorViewModel.Operation);
        }

        #endregion
    }
}
