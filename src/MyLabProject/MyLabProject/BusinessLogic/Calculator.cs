using Serilog;

namespace MyLabProject.BusinessLogic
{
    /// <summary>
    /// Клас для виконання математичних операцій
    /// </summary>
    public class Calculator
    {
        private readonly ILogger _logger;

        public Calculator()
        {
            _logger = Log.ForContext<Calculator>();
        }

        /// <summary>
        /// Додавання двох чисел
        /// </summary>
        public int Add(int a, int b)
        {
            _logger.Debug("Add method called with parameters: a={A}, b={B}", a, b);
            int result = a + b;
            _logger.Information("Add operation completed: {A} + {B} = {Result}", a, b, result);
            return result;
        }

        /// <summary>
        /// Віднімання двох чисел
        /// </summary>
        public int Subtract(int a, int b)
        {
            _logger.Debug("Subtract method called with parameters: a={A}, b={B}", a, b);
            int result = a - b;
            _logger.Information("Subtract operation completed: {A} - {B} = {Result}", a, b, result);
            return result;
        }

        /// <summary>
        /// Множення двох чисел
        /// </summary>
        public int Multiply(int a, int b)
        {
            _logger.Debug("Multiply method called with parameters: a={A}, b={B}", a, b);
            int result = a * b;
            _logger.Information("Multiply operation completed: {A} * {B} = {Result}", a, b, result);
            return result;
        }

        /// <summary>
        /// Ділення двох чисел
        /// </summary>
        public double Divide(int a, int b)
        {
            _logger.Debug("Divide method called with parameters: a={A}, b={B}", a, b);

            if (b == 0)
            {
                _logger.Error("Division by zero attempted: {A} / {B}", a, b);
                throw new DivideByZeroException("Ділення на нуль неможливе!");
            }

            double result = (double)a / b;
            _logger.Information("Divide operation completed: {A} / {B} = {Result}", a, b, result);
            return result;
        }

        /// <summary>
        /// Обчислення факторіалу числа
        /// </summary>
        public long Factorial(int n)
        {
            _logger.Debug("Factorial method called with parameter: n={N}", n);

            if (n < 0)
            {
                _logger.Error("Factorial called with negative number: {N}", n);
                throw new ArgumentException("Факторіал не визначений для від'ємних чисел");
            }

            if (n == 0 || n == 1)
            {
                _logger.Information("Factorial operation completed: {N}! = 1", n);
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }

            _logger.Information("Factorial operation completed: {N}! = {Result}", n, result);
            return result;
        }
    }
}