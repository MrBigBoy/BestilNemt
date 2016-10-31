namespace Models
{
    public class Company : Person
    {
        public Company(int id, string name, string email, string address, Login login, Shop shop) : base(id, name, email, address, login, shop)
        {
        }
    }
}
