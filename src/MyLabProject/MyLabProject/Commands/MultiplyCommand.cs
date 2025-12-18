using MyLabProject.BusinessLogic;
using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для множення двох чисел
    /// </summary>
    public class MultiplyCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly ILogger _logger;

        public MultiplyCommand(Calculator calculator)
        {
            _calculator = calculator;
            _logger = Log.ForContext<MultiplyCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Multiply command started");

            try
            {
                Console.WriteLine();
                Console.WriteLine("=== МНОЖЕННЯ ===");
                Console.Write("Введіть перше число: ");
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("❌ Помилка: введено некоректне число");
                    return Result.CONTINUE;
                }

                Console.Write("Введіть друге число: ");
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("❌ Помилка: введено некоректне число");
                    return Result.CONTINUE;
                }

                int result = _calculator.Multiply(a, b);
                Console.WriteLine($"✅ Результат: {a} * {b} = {result}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}");
                _logger.Error(ex, "Error in Multiply command");
            }

            return Result.CONTINUE;
        }

        public string Name()
        {
            return "multiply";
        }
    }
}