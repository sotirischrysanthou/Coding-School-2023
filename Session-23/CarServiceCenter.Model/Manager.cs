namespace CarServiceCenter.Model
{
    public class Manager
    {
        // Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SalaryPerMonth { get; set; }

        // Constractors
        public Manager(string name, string surname, int salaryPerMonth)
        {
            Name = name;
            Surname = surname;
            SalaryPerMonth = salaryPerMonth;

            Engineers = new List<Engineer>();
            Transactions = new List<Transaction>();
        }

        // Relations
        public List<Engineer> Engineers { get; set; }

        public List<Transaction> Transactions { get; set; }
    }
}
