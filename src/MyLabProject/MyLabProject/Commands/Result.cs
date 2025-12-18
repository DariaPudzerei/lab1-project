namespace MyLabProject.Commands
{
    /// <summary>
    /// Результат виконання команди
    /// </summary>
    public enum Result
    {
        /// <summary>
        /// Вийти з програми
        /// </summary>
        EXIT,

        /// <summary>
        /// Повернутися до попереднього меню
        /// </summary>
        RETURN,

        /// <summary>
        /// Продовжити роботу
        /// </summary>
        CONTINUE
    }
}