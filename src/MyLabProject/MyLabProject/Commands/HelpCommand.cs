using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для виведення довідки
    /// </summary>
    public class HelpCommand : ICommand
    {
        private readonly string _description;
        private readonly ILogger _logger;

        public HelpCommand(string description)
        {
            _description = description;
            _logger = Log.ForContext<HelpCommand>();
        }

        public Result Execute()
        {
            _logger.Debug("Help command executed");
            Console.WriteLine();
            Console.WriteLine("=== ДОВІДКА ===");
            Console.WriteLine(_description);
            Console.WriteLine();
            return Result.CONTINUE;
        }

        public string Name()
        {
            return "help";
        }
    }
}