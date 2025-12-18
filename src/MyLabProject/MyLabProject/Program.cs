using MyLabProject.BusinessLogic;
using MyLabProject.Commands;
using MyLabProject.Builders;
using Serilog;

namespace MyLabProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File(
                    path: "logs/app-.log",
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();

            try
            {
                Log.Information("=== Application started ===");
                Console.WriteLine("╔════════════════════════════════════════════════╗");
                Console.WriteLine("║   Калькулятор з командним інтерфейсом (Shell) ║");
                Console.WriteLine("╚════════════════════════════════════════════════╝");
                Console.WriteLine();

                // Демонстрація патерну Builder
                DemonstrateBuilder();

                // Створення калькулятора
                Calculator calculator = new Calculator();

                // Створення базових команд
                ReturnCommand returnCommand = new ReturnCommand();
                ExitCommand exitCommand = new ExitCommand();

                // Головне меню
                Menu mainMenu = new Menu("main");
                mainMenu.Add(exitCommand);
                mainMenu.Add(new HelpCommand("Головне меню програми. Виберіть підменю для роботи або exit для виходу."));

                // Підменю Calculator
                Menu calculatorMenu = new Menu("calculator");
                calculatorMenu.Add(returnCommand);
                calculatorMenu.Add(exitCommand);
                calculatorMenu.Add(new AddCommand(calculator));
                calculatorMenu.Add(new SubtractCommand(calculator));
                calculatorMenu.Add(new MultiplyCommand(calculator));
                calculatorMenu.Add(new DivideCommand(calculator));
                calculatorMenu.Add(new FactorialCommand(calculator));
                calculatorMenu.Add(new HelpCommand("Меню калькулятора. Виберіть операцію: add, subtract, multiply, divide, factorial."));

                // Додаємо підменю до головного
                mainMenu.Add(calculatorMenu);

                // Запуск головного меню
                mainMenu.Execute();

                Console.WriteLine();
                Console.WriteLine("Дякуємо за використання програми!");
                Log.Information("=== Application finished successfully ===");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Application crashed with unexpected error");
                Console.WriteLine($"Критична помилка: {ex.Message}");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        /// <summary>
        /// Демонстрація патерну Builder
        /// </summary>
        static void DemonstrateBuilder()
        {
            Console.WriteLine("=== Демонстрація патерну Builder ===");
            Console.WriteLine();

            try
            {
                // Приклад 1: Просте обчислення
                var calculation1 = CalculationBuilder.Create()
                    .WithDescription("Просте додавання")
                    .AddOperation("5 + 3")
                    .WithResult(8)
                    .Build();

                Console.WriteLine("Обчислення 1:");
                Console.WriteLine(calculation1);
                Console.WriteLine();

                // Приклад 2: Складне обчислення
                var calculation2 = CalculationBuilder.Create()
                    .WithDescription("Складне обчислення")
                    .AddOperation("10 + 5 = 15")
                    .AddOperation("15 * 2 = 30")
                    .AddOperation("30 - 10 = 20")
                    .WithResult(20)
                    .Build();

                Console.WriteLine("Обчислення 2:");
                Console.WriteLine(calculation2);
                Console.WriteLine();

                Console.WriteLine("✅ Патерн Builder працює коректно!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Помилка в Builder: {ex.Message}");
                Log.Error(ex, "Error demonstrating Builder pattern");
            }

            Console.WriteLine();
            Console.WriteLine("Натисніть Enter для переходу до Shell...");
            Console.ReadLine();
            Console.Clear();
        }
    }
}