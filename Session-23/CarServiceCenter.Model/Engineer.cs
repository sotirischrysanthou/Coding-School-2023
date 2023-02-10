namespace CarServiceCenter.Model
{
    public class Engineer
    {
        // Properties
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int SalaryPerMonth { get; set; }

        // Constractors
        public Engineer(String name, String surname, int salaryPerMonth)
        {
            Name = name;
            Surname = surname;
            SalaryPerMonth = salaryPerMonth;

            TransactionLines = new List<TransactionLine>();
        }

        // Relations
        public int ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;

        public List<TransactionLine> TransactionLines { get; set; }
    }
}
