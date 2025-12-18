namespace MyLabProject.BusinessLogic
{
    /// <summary>
    /// Клас для виконання математичних операцій
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Додавання двох чисел
        /// </summary>
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// Віднімання двох чисел
        /// </summary>
        public int Subtract(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// Множення двох чисел
        /// </summary>
        public int Multiply(int a, int b)
        {
            return a * b;
        }

        /// <summary>
        /// Ділення двох чисел
        /// </summary>
        public double Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Ділення на нуль неможливе!");
            }
            return (double)a / b;
        }

        /// <summary>
        /// Обчислення факторіалу числа
        /// </summary>
        public long Factorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("Факторіал не визначений для від'ємних чисел");
            }

            if (n == 0 || n == 1)
            {
                return 1;
            }

            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}