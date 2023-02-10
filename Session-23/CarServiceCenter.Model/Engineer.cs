namespace CarServiceCenter.Model
{
    public class Engineer
    {
        public Engineer(string name, string surname, int salaryPerMonth)
        {
            Name = name;
            Surname = surname;
            SalaryPerMonth = salaryPerMonth;

            TransactionLines = new List<TransactionLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SalaryPerMonth { get; set; }

        // Relations
        public int ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;

        public List<TransactionLine> TransactionLines { get; set; }
    }
}
