namespace CarServiceCenter.Model
{
    public class ServiceTask
    {
        // Properties
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal Hours { get; set; }

        
        // Constractors
        public ServiceTask(string code, string description, decimal hours)
        {
            Code = code;
            Description = description;
            Hours = hours;

            TransactionLines = new List<TransactionLine>();
        }

        // Relations
        public List<TransactionLine> TransactionLines { get; set; }
    }
}
