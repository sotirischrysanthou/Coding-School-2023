namespace CarServiceCenter.Model
{
    public class Manager
    {
        // Properties
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int SalaryPerMonth { get; set; }
        public DateTime StartDate { get; set; }


        // Constractors
        public Manager(String name, String surname, int salaryPerMonth)
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
    public class ManagerCreateDto {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int SalaryPerMonth { get; set; }
        public DateTime StartDate { get; set; }
    }
    public class ManagerEditDto {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int SalaryPerMonth { get; set; }
        public DateTime StartDate { get; set; }
    }
}
