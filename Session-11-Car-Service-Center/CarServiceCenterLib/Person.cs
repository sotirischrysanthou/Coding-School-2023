namespace CarServiceCenterLib {
    public class Person {

        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Constructors

        public Person() {
            ID = Guid.NewGuid();
        }

        public Person(String name, String surname) {
            ID = Guid.NewGuid();
            Name = name;
            Surname = surname;
        }
    }
}