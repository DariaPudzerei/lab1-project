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
                Log.Information("Application started");
                Console.WriteLine("Hello! It is a new project!!!");
                Console.WriteLine();

                // Демонстрація роботи Calculator
                Calculator calc = new Calculator();

                Console.WriteLine("=== Демонстрація Calculator ===");
                Console.WriteLine($"5 + 3 = {calc.Add(5, 3)}");
                Console.WriteLine($"10 - 4 = {calc.Subtract(10, 4)}");
                Console.WriteLine($"6 * 7 = {calc.Multiply(6, 7)}");
                Console.WriteLine($"15 / 3 = {calc.Divide(15, 3)}");
                Console.WriteLine($"5! = {calc.Factorial(5)}");

                Console.WriteLine();
                Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
                Console.ReadLine();

                Log.Information("Application finished successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Application crashed with error");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}