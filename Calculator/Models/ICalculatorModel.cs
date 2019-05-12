using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Models
{
    public interface ICalculatorModel
    {
        string LeftOperand { get; set; }
        string RightOperand { get; set; }
        string Operation { get; set; }
        string Result { get; }

        void CalculateResult();
        void ChangeLeftOperandSign();
        void ChangeRightOperandSign();
    }
}
