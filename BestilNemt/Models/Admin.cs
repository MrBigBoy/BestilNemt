namespace Models
{
    public class Admin : Person
    {
        public Admin(int id, string name, string email, string address, Login login, Shop shop, string personType) : base(id, name, email, address, login, shop, personType)
        {

        }
    }
}
