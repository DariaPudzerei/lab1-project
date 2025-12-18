namespace MyLabProject.Builders
{
    /// <summary>
    /// Клас для збереження складного обчислення
    /// </summary>
    public class Calculation
    {
        public string Description { get; set; }
        public List<string> Operations { get; set; }
        public double? Result { get; set; }

        public Calculation()
        {
            Description = string.Empty;
            Operations = new List<string>();
            Result = null;
        }

        public override string ToString()
        {
            return $"Calculation: {Description}\n" +
                   $"Operations: {string.Join(" -> ", Operations)}\n" +
                   $"Result: {(Result.HasValue ? Result.Value.ToString() : "Not calculated")}";
        }
    }
}