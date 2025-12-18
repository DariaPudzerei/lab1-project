using Serilog;

namespace MyLabProject.Builders
{
    /// <summary>
    /// Будівельник для створення складних обчислень (патерн Builder)
    /// </summary>
    public class CalculationBuilder
    {
        private readonly Calculation _calculation;
        private readonly ILogger _logger;

        private CalculationBuilder()
        {
            _calculation = new Calculation();
            _logger = Log.ForContext<CalculationBuilder>();
            _logger.Debug("CalculationBuilder created");
        }

        /// <summary>
        /// Створити новий будівельник
        /// </summary>
        public static CalculationBuilder Create()
        {
            return new CalculationBuilder();
        }

        /// <summary>
        /// Встановити опис обчислення
        /// </summary>
        public CalculationBuilder WithDescription(string description)
        {
            if (string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("Description cannot be empty", nameof(description));
            }

            _calculation.Description = description;
            _logger.Debug("Description set: {Description}", description);
            return this;
        }

        /// <summary>
        /// Додати операцію до обчислення
        /// </summary>
        public CalculationBuilder AddOperation(string operation)
        {
            if (string.IsNullOrWhiteSpace(operation))
            {
                throw new ArgumentException("Operation cannot be empty", nameof(operation));
            }

            _calculation.Operations.Add(operation);
            _logger.Debug("Operation added: {Operation}", operation);
            return this;
        }

        /// <summary>
        /// Встановити результат обчислення
        /// </summary>
        public CalculationBuilder WithResult(double result)
        {
            _calculation.Result = result;
            _logger.Debug("Result set: {Result}", result);
            return this;
        }

        /// <summary>
        /// Побудувати фінальний об'єкт Calculation
        /// </summary>
        public Calculation Build()
        {
            // Валідація
            if (string.IsNullOrWhiteSpace(_calculation.Description))
            {
                _logger.Error("Build failed: Description is missing");
                throw new InvalidOperationException("Description is required");
            }

            if (_calculation.Operations.Count == 0)
            {
                _logger.Warning("Build: No operations added");
            }

            _logger.Information("Calculation built successfully: {Description}", _calculation.Description);
            return _calculation;
        }
    }
}