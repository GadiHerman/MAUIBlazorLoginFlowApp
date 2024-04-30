namespace DataClassLibrary
{
    public class Customer
    {
        public Customer(int id, string name, int age, string password)
        {
            Id = id;
            Name = name;
            Age = age;
            Password = password;
        }

        public Customer()
        {
            Id = -1;
            Name = "";
            Age = 0;
            Password = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
    }

}
