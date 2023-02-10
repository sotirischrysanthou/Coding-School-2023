namespace CarServiceCenter.Model
{
    public class TransactionLine
    {
        public TransactionLine(decimal hours, decimal pricePerHour, decimal price)
        {
            Hours = hours;
            PricePerHour = pricePerHour;
            Price = price;
        }

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
    }
}
