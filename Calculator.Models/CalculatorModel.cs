using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorModel :ICalculatorModel
    {
        public string LeftOperand { get; set; }
        public string RightOperand { get; set; }
        public string Operation { get; set; }
        public string Result { get; private set; }

        public CalculatorModel()
        {
                LeftOperand = String.Empty;
                RightOperand = String.Empty;
                Operation = String.Empty;
                Result = String.Empty;
        }

        public CalculatorModel(string leftOperand, string rightOperand, string operation)
        {
            LeftOperand = leftOperand;
            RightOperand = rightOperand;
            Operation = operation;
            Result = String.Empty;
        }

        public void CalculateResult()
        {
            try
            {
                var leftOperand = Int32.Parse(LeftOperand);
                var rightOperand = Int32.Parse(RightOperand);

                switch (Operation)
                {
                    case "+":
                    {
                        Result = checked(leftOperand + rightOperand).ToString();
                        break;
                    }
                    case "-":
                    {
                        Result = checked(leftOperand - rightOperand).ToString();
                        break;
                    }
                    case "*":
                    {
                        Result = checked(leftOperand * rightOperand).ToString();
                        break;
                    }
                    case "/":
                    {
                        Result = checked(leftOperand / rightOperand).ToString();
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Result = "Calculation Error";
                LeftOperand = string.Empty;
                RightOperand = string.Empty;
                Operation = string.Empty;
                Trace.WriteLine($"Exception occured in {nameof(CalculateResult)}.");
                Trace.WriteLine($"Exception Original Message: {e.Message}.");
                Trace.WriteLine($"Exception Stack Trace: {e.StackTrace}.");
            }
        }

        public void ChangeLeftOperandSign()
        {
            
            LeftOperand = (-1 * Int32.Parse(LeftOperand)).ToString();
           
        }

        public void ChangeRightOperandSign()
        {
            RightOperand = (-1 * Int32.Parse(RightOperand)).ToString();
        }
    }
}
