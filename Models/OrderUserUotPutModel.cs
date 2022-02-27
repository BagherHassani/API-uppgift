namespace _02_API.Models
{
    public class OrderUserUotPutModel
    {
        public OrderUserUotPutModel(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
