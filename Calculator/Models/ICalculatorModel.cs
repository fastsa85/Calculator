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
