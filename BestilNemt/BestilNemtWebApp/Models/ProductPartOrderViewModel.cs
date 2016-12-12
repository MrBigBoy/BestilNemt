using WebClient.BestilNemtServiceRef;

namespace WebClient.Models
{
    /// <summary>
    /// This view model is used to show all products
    /// </summary>
    public class ProductPartOrderViewModel
    {
        public Product Product { get; set; }

        public Cart Cart { get; set; }

        public int Amount { get; set; }

    }
}