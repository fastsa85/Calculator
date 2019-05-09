using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public class CalculatorModel
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
                        Result = (leftOperand + rightOperand).ToString();
                        break;
                    }
                    case "-":
                    {
                        Result = (leftOperand - rightOperand).ToString();
                        break;
                    }
                    case "*":
                    {
                        Result = (leftOperand * rightOperand).ToString();
                        break;
                    }
                    case "/":
                    {
                        Result = (leftOperand / rightOperand).ToString();
                        break;
                    }
                }
            }
            catch
            {
                Result = "Calculation Error";
                throw;
            }
        }
    }
}
