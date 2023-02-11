namespace CarServiceCenter.Model
{
    public class Customer
    {
        // Properties
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Phone { get; set; }
        public String Tin { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }

        // Constractors
        public Customer(String name, String surname, String phone, String tin)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Tin = tin;

            Transactions = new List<Transaction>();
        }
    }

    public class CustomerCreateDto {
        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;
        public String Phone { get; set; } = null!;
        public String Tin { get; set; } = null!;
    }
    public class CustomerEditDto {
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;
        public String Phone { get; set; } = null!;
        public String Tin { get; set; } = null!;
    }
}
