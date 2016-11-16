namespace Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int MinStock { get; set; }
        public Product Product { get; set; }
        public Shop Shop { get; set; }

        public Warehouse()
        {
               
        }

        public Warehouse(int id, int stock, int minStock, Product product, Shop shop)
        {
            Id = id;
            Stock = stock;
            MinStock = minStock;
            Product = product;
            Shop = shop;
        }
    }
}
