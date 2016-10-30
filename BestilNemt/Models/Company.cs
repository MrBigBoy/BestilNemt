namespace Models
{
    public class Company : Person
    {
        public Company(int id, string name, string email, string address) : base(id, name, email, address)
        {
        }
    }
}
