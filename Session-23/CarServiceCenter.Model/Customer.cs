namespace CarServiceCenter.Model
{
    public class Customer
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Phone { get; set; }
        public string Tin { get; set; }

        // Constractors
        public Customer(string name, string surname, int phone, string tin)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Tin = tin;

            Transactions = new List<Transaction>();
        }

        // Relations
        public List<Transaction> Transactions { get; set; }
    }
}
