using WebClient.BestilNemtServiceRef;
namespace WebClient.Models
{
    /// <summary>
    /// This viewModel is used to create a person with a login.
    /// The model is used to store more than one object
    /// </summary>
    public class CreatePersonViewModel
    {
        public Login Login { get; set; }

        public Customer Customer { get; set; }
    }
}