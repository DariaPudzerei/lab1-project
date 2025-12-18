namespace MyLabProject.Commands
{
    /// <summary>
    /// Інтерфейс для всіх команд у shell
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Виконати команду
        /// </summary>
        Result Execute();

        /// <summary>
        /// Отримати назву команди
        /// </summary>
        string Name();
    }
}