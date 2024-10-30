namespace ProductApp
{
    public interface ICalculatorService
    {
        int Add(int num1, int num2);
        int Multiply(int num1, int num2);
        int Divide(int num1, int num2);
        int Subtraction(int num1, int num2);
    }
}
