using Serilog;
using System.Collections.Generic;

namespace MyLabProject.Commands
{
    /// <summary>
    /// Меню як контейнер команд (патерн Composite)
    /// </summary>
    public class Menu : ICommand
    {
        private readonly string _name;
        private readonly Dictionary<string, ICommand> _commands;
        private readonly ILogger _logger;

        public Menu(string name)
        {
            _name = name;
            _commands = new Dictionary<string, ICommand>();
            _logger = Log.ForContext<Menu>();
        }

        /// <summary>
        /// Додати команду до меню
        /// </summary>
        public void Add(ICommand command)
        {
            _commands[command.Name()] = command;
            _logger.Debug("Command '{CommandName}' added to menu '{MenuName}'", command.Name(), _name);
        }

        /// <summary>
        /// Видалити команду з меню
        /// </summary>
        public void Remove(string commandName)
        {
            if (_commands.Remove(commandName))
            {
                _logger.Debug("Command '{CommandName}' removed from menu '{MenuName}'", commandName, _name);
            }
        }

        public Result Execute()
        {
            _logger.Information("Menu '{MenuName}' started", _name);

            if (_commands.Count == 0)
            {
                Console.WriteLine("Меню порожнє. Повертаємося...");
                _logger.Warning("Menu '{MenuName}' is empty", _name);
                return Result.CONTINUE;
            }

            Result result;
            do
            {
                result = Result.CONTINUE;
                Prompt();

                string? commandName = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(commandName))
                {
                    Console.WriteLine("Команда не може бути порожньою. Спробуйте ще раз.");
                    continue;
                }

                if (_commands.TryGetValue(commandName, out ICommand? command))
                {
                    _logger.Debug("Executing command '{CommandName}' in menu '{MenuName}'", commandName, _name);
                    result = command.Execute();
                }
                else
                {
                    Console.WriteLine($"Команда '{commandName}' не знайдена. Спробуйте ще раз.");
                    _logger.Warning("Unknown command '{CommandName}' in menu '{MenuName}'", commandName, _name);
                }

            } while (result == Result.CONTINUE);

            _logger.Information("Menu '{MenuName}' finished with result: {Result}", _name, result);

            return result == Result.EXIT ? Result.EXIT : Result.CONTINUE;
        }

        public string Name()
        {
            return _name;
        }

        /// <summary>
        /// Вивести підказку з доступними командами
        /// </summary>
        private void Prompt()
        {
            Console.WriteLine();
            Console.WriteLine($"╔═══════════════════════════════════════╗");
            Console.WriteLine($"║  Меню: {_name,-30} ║");
            Console.WriteLine($"╚═══════════════════════════════════════╝");
            Console.WriteLine("Доступні команди:");

            foreach (var commandName in _commands.Keys)
            {
                Console.WriteLine($"  • {commandName}");
            }

            Console.WriteLine();
            Console.Write("Введіть команду > ");
        }
    }
}