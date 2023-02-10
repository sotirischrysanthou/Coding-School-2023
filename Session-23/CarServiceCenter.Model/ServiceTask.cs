namespace CarServiceCenter.Model
{
    public class ServiceTask
    {
        // Properties
        public int Id { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }
        public decimal Hours { get; set; }

        
        // Constractors
        public ServiceTask(String code, String description, decimal hours)
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
