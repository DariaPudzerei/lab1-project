using Serilog;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Команда для повернення до попереднього меню
    /// </summary>
    public class ReturnCommand : ICommand
    {
        private readonly ILogger _logger;

        public ReturnCommand()
        {
            _logger = Log.ForContext<ReturnCommand>();
        }

        public Result Execute()
        {
            _logger.Information("Return command executed");
            Console.WriteLine("Повернення до попереднього меню...");
            return Result.RETURN;
        }

        public string Name()
        {
            return "return";
        }
    }
}