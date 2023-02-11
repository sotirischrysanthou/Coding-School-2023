namespace CarServiceCenter.Model
{
    public class Car
    {
        // Properties
        public int Id { get; set; }
        public String Brand { get; set; }
        public String Model { get; set; }
        public String CarRegistrationNumber { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }
        
        // Constractors
        public Car(String brand, String model, String carRegistrationNumber)
        {
            Brand = brand;
            Model = model;
            CarRegistrationNumber = carRegistrationNumber;

            Transactions = new List<Transaction>();
        }
    }
    public class CarCreateDto {
        public String Brand { get; set; } = null!;
        public String Model { get; set; } = null!;
        public String CarRegistrationNumber { get; set; } = null!;
    }
    public class CarEditDto {
        public int Id { get; set; }
        public String Brand { get; set; } = null!;
        public String Model { get; set; } = null!;
        public String CarRegistrationNumber { get; set; } = null!;
    }
}
