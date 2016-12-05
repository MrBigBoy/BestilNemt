using WebClient.BestilNemtServiceRef;

namespace WebClient.Models
{
    public class ProductPartOrderViewModel
    {
        public Product Product { get; set; }

        public Cart Cart { get; set; }
        public int Amount { get; set; }

    }
}