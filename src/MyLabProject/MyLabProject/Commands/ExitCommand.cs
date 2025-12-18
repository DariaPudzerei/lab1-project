using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для виходу з програми
    /// </summary>
    public class ExitCommand : ICommand
    {
        private readonly ILogger _logger;

        public ExitCommand()
        {
            _logger = Log.ForContext<ExitCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Exit command executed");
            Console.WriteLine("Вихід з програми...");
            return Result.EXIT;
        }

        public string Name()
        {
            return "exit";
        }
    }
}