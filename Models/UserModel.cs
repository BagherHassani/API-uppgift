namespace _02_API.Models
{
    public class UserModel
    {
        public UserModel(string firstName, string lastName, string email, string password, string streetName, string postalCode, string city)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            StreetName = streetName;
            PostalCode = postalCode;
            City = city;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StreetName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
}
