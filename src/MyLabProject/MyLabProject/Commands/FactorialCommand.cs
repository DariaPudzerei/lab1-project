using MyLabProject.BusinessLogic;
using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для обчислення факторіалу
    /// </summary>
    public class FactorialCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly ILogger _logger;

        public FactorialCommand(Calculator calculator)
        {
            _calculator = calculator;
            _logger = Log.ForContext<FactorialCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Factorial command started");

            try
            {
                Console.WriteLine();
                Console.WriteLine("=== ФАКТОРІАЛ ===");
                Console.Write("Введіть невід'ємне ціле число: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                {
                    Console.WriteLine("❌ Помилка: введено некоректне число");
                    return Result.CONTINUE;
                }

                long result = _calculator.Factorial(n);
                Console.WriteLine($"✅ Результат: {n}! = {result}");
                Console.WriteLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}");
                _logger.Warning("Invalid argument for factorial: {Message}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}");
                _logger.Error(ex, "Error in Factorial command");
            }

            return Result.CONTINUE;
        }

        public string Name()
        {
            return "factorial";
        }
    }
}