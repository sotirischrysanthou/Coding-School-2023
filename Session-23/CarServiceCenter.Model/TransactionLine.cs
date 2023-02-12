namespace CarServiceCenter.Model {
    public class TransactionLine {
        // Properties
        public int Id { get; set; }
        public decimal Hours { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Price { get; set; }
        // Relations
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; } = null!;

        public int ServiceTaskId { get; set; }
        public ServiceTask ServiceTask { get; set; } = null!;

        public int EngineerId { get; set; }
        public Engineer Engineer { get; set; } = null!;

        // Constractors
        public TransactionLine() {

        }
        public TransactionLine(decimal hours, decimal pricePerHour) {
            Hours = hours;
            PricePerHour = pricePerHour;
            Price = pricePerHour * hours;
        }
        public TransactionLine(decimal hours, decimal pricePerHour, decimal price) {
            Hours = hours;
            PricePerHour = pricePerHour;
            Price = price;
        }
    }

    public class TransactionLineCreateDto {
        public decimal PricePerHour { get; set; }
        public int ServiceTaskId { get; set; }
        public int EngineerId { get; set; }
        public int TransactionId { get; set; }
    }

    public class TransactionLineEditDto {
        public int Id { get; set; }
        public decimal PricePerHour { get; set; }
        public int ServiceTaskId { get; set; }
        public int EngineerId { get; set; }
    }
}
