using MyLabProject.BusinessLogic;
using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для додавання двох чисел
    /// </summary>
    public class AddCommand : ICommand
    {
        private readonly Calculator _calculator;
        private readonly ILogger _logger;

        public AddCommand(Calculator calculator)
        {
            _calculator = calculator;
            _logger = Log.ForContext<AddCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Add command started");

            try
            {
                Console.WriteLine();
                Console.WriteLine("=== ДОДАВАННЯ ===");
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

                int result = _calculator.Add(a, b);
                Console.WriteLine($"✅ Результат: {a} + {b} = {result}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка: {ex.Message}");
                _logger.Error(ex, "Error in Add command");
            }

            return Result.CONTINUE;
        }

        public string Name()
        {
            return "add";
        }
    }
}