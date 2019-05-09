using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calculator.Commands;
using Calculator.Models;

namespace Calculator.ViewModels
{
    public class CalculatorViewModel : BaseViewModel
    {
        #region Private members

        private string display;

        private CalculatorModel calculatorModel;

        private DelegateCommand<string> digitButtonPressCommand;
        private DelegateCommand<string> operationButtonPressCommand;

        #endregion

        #region Constructors

        public CalculatorViewModel()
        {
            calculatorModel = new CalculatorModel();
            display = "0";
        }

        #endregion

        #region Public Properties

        public string LeftOperand
        {
            get { return calculatorModel.LeftOperand; }
            set { calculatorModel.LeftOperand = value; }
        }

        public string RightOperand
        {
            get { return calculatorModel.RightOperand; }
            set { calculatorModel.RightOperand = value; }
        }

        public string Operation
        {
            get { return calculatorModel.Operation; }
            set { calculatorModel.Operation = value; }
        }

        public string Display
        {
            get { return display; }
            set
            {
                display = value;
                OnPropertyChanged("Display");
            }
        }

        #endregion

        #region Commands

        #region Digit Buttons Press

        public ICommand DigitButtonPressCommand
        {
            get
            {
                if (digitButtonPressCommand == null)
                    digitButtonPressCommand = new DelegateCommand<string>(DigitButtonPress, CanDigitButtonPress);
                return digitButtonPressCommand;
            }
        }

        private bool CanDigitButtonPress(string button)
        {
            return true;
        }

        public void DigitButtonPress(string button)
        {
            switch (button)
            {
                case "CLEAR":
                {
                    Display = "0";
                    LeftOperand = string.Empty;
                    RightOperand = string.Empty;
                    Operation = string.Empty;
                    break;
                }
                default:
                {
                    if (Operation == string.Empty)
                    {
                        LeftOperand = LeftOperand + button;
                        Display = LeftOperand;
                    }
                    else
                    {
                        RightOperand = RightOperand + button;
                        Display = LeftOperand + Operation + RightOperand;
                    }

                    break;
                }
            }
        }

        #endregion

        #region Operation Button Press

        public ICommand OperationButtonPressCommand
        {
            get
            {
                if (operationButtonPressCommand == null)
                    operationButtonPressCommand = new DelegateCommand<string>(OperationButtonPress, CanOperationButtonPress);
                return operationButtonPressCommand;
            }
        }

        private bool CanOperationButtonPress(string button)
        {
            return LeftOperand != string.Empty;
        }

        public void OperationButtonPress(string button)
        {
            switch (button)
            {
                case "+":
                {
                    if (RightOperand != string.Empty)
                    {
                        calculatorModel.CalculateResult();
                        Operation = "+";
                        LeftOperand = calculatorModel.Result;
                        RightOperand = String.Empty;
                        Display = LeftOperand + Operation;
                    }
                    else
                    {
                        Operation = "+";
                        Display = Display + Operation;
                    }
                    break;
                }
                case "-":
                {
                    if (RightOperand != string.Empty)
                    {
                        calculatorModel.CalculateResult();
                        Operation = "-";
                        LeftOperand = calculatorModel.Result;
                        RightOperand = String.Empty;
                        Display = LeftOperand + Operation;
                    }
                    else
                    {
                        Operation = "-";
                        Display = Display + Operation;
                    }
                    break;
                }
                case "*":
                {
                    if (RightOperand != string.Empty)
                    {
                        calculatorModel.CalculateResult();
                        Operation = "*";
                        LeftOperand = calculatorModel.Result;
                        RightOperand = String.Empty;
                        Display = LeftOperand + Operation;
                    }
                    else
                    {
                        Operation = "*";
                        Display = Display + Operation;
                    }
                    break;
                }
                case "/":
                {
                    if (RightOperand != string.Empty)
                    {
                        calculatorModel.CalculateResult();
                        Operation = "/";
                        LeftOperand = calculatorModel.Result;
                        RightOperand = String.Empty;
                        Display = LeftOperand + Operation;
                    }
                    else
                    {
                        Operation = "/";
                        Display = Display + Operation;
                    }
                    break;
                }
                case "=":
                {
                    if (RightOperand != string.Empty)
                    {
                        calculatorModel.CalculateResult();
                        Operation = string.Empty;
                        LeftOperand = calculatorModel.Result;
                        RightOperand = String.Empty;
                        Display = LeftOperand;
                    }
                    break;
                }
                default:
                    throw new ArgumentException();
            }
        }

        #endregion

        #endregion


    }
}
