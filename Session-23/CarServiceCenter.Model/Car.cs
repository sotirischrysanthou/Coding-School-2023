namespace CarServiceCenter.Model
{
    public class Car
    {
        public Car(string brand, string model, string carRegistrationNumber)
        {
            Brand = brand;
            Model = model;
            CarRegistrationNumber = carRegistrationNumber;

            Transactions = new List<Transaction>();
        }

        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string CarRegistrationNumber { get; set; }

        // Relations
        public List<Transaction> Transactions { get; set; }
    }
}
