namespace CoffeeShop.Model
{
    public class Customer
    {
        // Properties
        public int Id { get; set; }
        public String Code { get; set; }
        public String Description { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }

        // Constructors
        public Customer(String code, String description)
        {
            Code = code;
            Description = description;

            Transactions = new List<Transaction>();
        }

    }
}
