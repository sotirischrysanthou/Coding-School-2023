namespace CarServiceCenter.Model
{
    public class ServiceTask
    {
        // Properties
        public int Id { get; set; }
        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
        public decimal Hours { get; set; }

        // Relations
        public List<TransactionLine> TransactionLines { get; set; }
        
        // Constractors
        public ServiceTask(String code, String description, decimal hours)
        {
            Code = code;
            Description = description;
            Hours = hours;

            TransactionLines = new List<TransactionLine>();
        }
    }
    public class ServiceTaskCreateDto {
        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
        public decimal Hours { get; set; }
    }
    public class ServiceTaskEditDto {
        public int Id { get; set; }
        public String Code { get; set; } = null!;
        public String Description { get; set; } = null!;
        public decimal Hours { get; set; }
    }
}
