namespace CarServiceCenter.Model
{
    public class Engineer
    {
        // Properties
        public int Id { get; set; }
        public String Name { get; set; } = null!;
        public String Surname { get; set; } = null!;
        public int SalaryPerMonth { get; set; }

        // Relations
        public int ManagerId { get; set; }
        public Manager Manager { get; set; } = null!;

        public List<TransactionLine> TransactionLines { get; set; }

        // Constractors
        public Engineer(String name, String surname, int salaryPerMonth)
        {
            Name = name;
            Surname = surname;
            SalaryPerMonth = salaryPerMonth;

            TransactionLines = new List<TransactionLine>();
        }
    }
    public class EngineerCreateDto {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int SalaryPerMonth { get; set; }
        public int ManagerId { get; set; }
    }
    public class EngineerEditDto {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int SalaryPerMonth { get; set; }
        public int ManagerId { get; set; }

    }
}
