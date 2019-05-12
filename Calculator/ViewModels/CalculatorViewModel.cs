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

        private string _display;

        private ICalculatorModel _calculatorModel;

        private DelegateCommand<string> digitButtonPressCommand;
        private DelegateCommand<string> operationButtonPressCommand;
        private DelegateCommand<string> positiveNegativePressCommand;

        #endregion

        #region Constructors

        public CalculatorViewModel()
        {
            this._calculatorModel = new CalculatorModel();
            _display = "0";
        }

        public CalculatorViewModel(ICalculatorModel calculatorModel)
        {
            _calculatorModel = calculatorModel;
            _display = "0";
        }

        #endregion

        #region Public Properties

        public string LeftOperand
        {
            get { return _calculatorModel.LeftOperand; }
            set { _calculatorModel.LeftOperand = value; }
        }

        public string RightOperand
        {
            get { return _calculatorModel.RightOperand; }
            set { _calculatorModel.RightOperand = value; }
        }

        public string Operation
        {
            get { return _calculatorModel.Operation; }
            set { _calculatorModel.Operation = value; }
        }

        public string Display
        {
            get { return _display; }
            set
            {
                _display = value;
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
                case "BACKSPACE":
                {
                    if (Operation != string.Empty && RightOperand == string.Empty)
                    {
                        Operation = string.Empty;
                        Display = LeftOperand;
                    }
                    else if (Operation != string.Empty && RightOperand != string.Empty)
                    {
                        RightOperand = RightOperand.Remove(RightOperand.Length - 1);
                        Display = LeftOperand + Operation + RightOperand;
                    }
                    else if (LeftOperand != string.Empty)
                    {
                        LeftOperand = LeftOperand.Remove(LeftOperand.Length - 1);
                        if (LeftOperand != string.Empty)
                            Display = LeftOperand;
                        else
                        {
                            Display = "0";
                        }
                    }
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
            if (LeftOperand != string.Empty)
            {
                switch (button)
                {
                    case "+":
                    {
                        if (RightOperand != string.Empty)
                        {
                            _calculatorModel.CalculateResult();
                            Operation = "+";
                            LeftOperand = _calculatorModel.Result;
                            RightOperand = String.Empty;
                        }
                        else
                        {
                            Operation = "+";
                        }
                        Display = LeftOperand + Operation;
                        break;
                    }
                    case "-":
                    {
                        if (RightOperand != string.Empty)
                        {
                            _calculatorModel.CalculateResult();
                            Operation = "-";
                            LeftOperand = _calculatorModel.Result;
                            RightOperand = String.Empty;
                        }
                        else
                        {
                            Operation = "-";
                        }
                        Display = LeftOperand + Operation;
                        break;
                    }
                    case "*":
                    {
                        if (RightOperand != string.Empty)
                        {
                            _calculatorModel.CalculateResult();
                            Operation = "*";
                            LeftOperand = _calculatorModel.Result;
                            RightOperand = String.Empty;
                        }
                        else
                        {
                            Operation = "*";
                        }
                        Display = LeftOperand + Operation;
                        break;
                    }
                    case "/":
                    {
                        if (RightOperand != string.Empty)
                        {
                            _calculatorModel.CalculateResult();
                            Operation = "/";
                            LeftOperand = _calculatorModel.Result;
                            RightOperand = String.Empty;
                        }
                        else
                        {
                            Operation = "/";
                        }
                        Display = LeftOperand + Operation;
                        break;
                    }
                    case "=":
                    {
                        if (RightOperand != string.Empty)
                        {
                            _calculatorModel.CalculateResult();
                            Operation = string.Empty;
                            LeftOperand = _calculatorModel.Result;
                            RightOperand = String.Empty;
                            Display = LeftOperand;
                        }
                        break;
                    }
                    default:
                        throw new ArgumentException();
                }
            }
        }

        #endregion

        #region Positive/Negative Buttons Press

        public ICommand PositiveNegativePressCommand
        {
            get
            {
                if (positiveNegativePressCommand == null)
                    positiveNegativePressCommand =
                        new DelegateCommand<string>(PositiveNegativeButtonPress, CanPositiveNegativeButtonPress);
                return positiveNegativePressCommand;
            }
        }

        private bool CanPositiveNegativeButtonPress(string button)
        {
            return (LeftOperand != string.Empty && Operation == string.Empty) || (RightOperand != string.Empty);
        }

        public void PositiveNegativeButtonPress(string button)
        {
            if (LeftOperand != string.Empty && Operation == string.Empty)
            {
                _calculatorModel.ChangeLeftOperandSign();
                Display = LeftOperand;
            }
            else if (RightOperand != string.Empty)
            {
                _calculatorModel.ChangeRightOperandSign();
                Display = LeftOperand + Operation + RightOperand; 
            }
        }

        #endregion

        #endregion


    }
}
