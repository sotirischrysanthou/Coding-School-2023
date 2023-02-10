namespace CarServiceCenter.Model
{
    public class Transaction
    {
        // Properties
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        // Relations
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public int ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;

        public int CarId { get; set; }
        public Car Car { get; set; } = null!;

        public List<TransactionLine> TransactionLines { get; set; }

        // Constractors
        public Transaction() {
            Date = DateTime.Now;
            TotalPrice = 0;

            TransactionLines = new List<TransactionLine>();
        }

        public Transaction(decimal totalPrice)
        {
            Date = DateTime.Now;
            TotalPrice = totalPrice;

            TransactionLines = new List<TransactionLine>();
        }

        // Methods
        public void AddTransactionLine(TransactionLine transactionLine) {
            TransactionLines.Add(transactionLine);
            UpdateTotalPrice();
        }

        public void UpdateTotalPrice() {
            TotalPrice = 0;
            foreach (TransactionLine transactionLine in TransactionLines) {
                TotalPrice += transactionLine.Price;
            }
        }
    }
}
