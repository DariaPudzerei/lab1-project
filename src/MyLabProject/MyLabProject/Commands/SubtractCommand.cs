using MyLabProject.BusinessLogic;
using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для віднімання двох чисел
    /// </summary>
    public class SubtractCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly ILogger _logger;

        public SubtractCommand(Calculator calculator)
        {
            _calculator = calculator;
            _logger = Log.ForContext<SubtractCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Subtract command started");

            try
            {
                Console.WriteLine();
                Console.WriteLine("=== ВІДНІМАННЯ ===");
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

                int result = _calculator.Subtract(a, b);
                Console.WriteLine($"✅ Результат: {a} - {b} = {result}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}");
                _logger.Error(ex, "Error in Subtract command");
            }

            return Result.CONTINUE;
        }

        public string Name()
        {
            return "subtract";
        }
    }
}