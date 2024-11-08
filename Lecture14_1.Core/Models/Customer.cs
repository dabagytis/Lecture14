namespace Lecture14_1.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Customer()
        {

        }

        public override string ToString()
        {
            return $"ID: {Id}; Name: {FirstName} {LastName}; Email: {Email}; Phone: {PhoneNumber}";
        }
    }
}
