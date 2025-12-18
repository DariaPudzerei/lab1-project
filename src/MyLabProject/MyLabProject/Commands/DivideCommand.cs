using MyLabProject.BusinessLogic;
using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для ділення двох чисел
    /// </summary>
    public class DivideCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly ILogger _logger;

        public DivideCommand(Calculator calculator)
        {
            _calculator = calculator;
            _logger = Log.ForContext<DivideCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Divide command started");

            try
            {
                Console.WriteLine();
                Console.WriteLine("=== ДІЛЕННЯ ===");
                Console.Write("Введіть перше число (ділене): ");
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("❌ Помилка: введено некоректне число");
                    return Result.CONTINUE;
                }

                Console.Write("Введіть друге число (дільник): ");
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("❌ Помилка: введено некоректне число");
                    return Result.CONTINUE;
                }

                double result = _calculator.Divide(a, b);
                Console.WriteLine($"✅ Результат: {a} / {b} = {result}");
                Console.WriteLine();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("❌ Помилка: ділення на нуль неможливе!");
                _logger.Warning("Division by zero attempted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}");
                _logger.Error(ex, "Error in Divide command");
            }

            return Result.CONTINUE;
        }

        public string Name()
        {
            return "divide";
        }
    }
}