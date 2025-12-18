using MyLabProject.BusinessLogic;
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
                Console.WriteLine("Hello! It is a new project!!!");
                Console.WriteLine();

                Calculator calc = new Calculator();

                Console.WriteLine("=== Демонстрація Calculator ===");
                Console.WriteLine();

                // Успішні операції
                Console.WriteLine("--- Успішні операції ---");
                Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
                Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}");
                Console.WriteLine($"6 * 7 = {calc.Multiply(6, 7)}");
                Console.WriteLine($"15 / 3 = {calc.Divide(15, 3)}");
                Console.WriteLine($"5! = {calc.Factorial(5)}");

                Console.WriteLine();
                Console.WriteLine("--- Тест обробки помилок ---");

                // Тест 1: Ділення на нуль
                try
                {
                    Console.WriteLine("Спроба поділити 10 / 0...");
                    calc.Divide(10, 0);
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"❌ Помилка: {ex.Message}");
                    Log.Warning("Division by zero was handled in main program");
                }

                Console.WriteLine();

                // Тест 2: Негативний факторіал
                try
                {
                    Console.WriteLine("Спроба обчислити (-5)!...");
                    calc.Factorial(-5);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"❌ Помилка: {ex.Message}");
                    Log.Warning("Negative factorial was handled in main program");
                }

                Console.WriteLine();
                Console.WriteLine("=== Перевірте файл логів у папці logs/ ===");
                Console.WriteLine();
                Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                Console.ReadLine();

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
    }
}