using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("SignIn", "Login");
        }

        public ActionResult SignIn()
        {
            var login = Login;
            Session["login"] = login;
            return View(login);
        }

        public ActionResult CreateLogin()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer,Login login)
        {

            var proxy = new BestilNemtServiceClient();
            login.Username = customer.Email;
            proxy.CreateWithCustomer(customer, login); 
            
            return RedirectToAction("Index"); 
        }

        public ActionResult ResetLogin()
        {
            var login = Login;
            return View(login);
        }

        public Login Login
        {
            get
            {
                if (Session["Login"] != null)
                    return (Login)Session["Login"];
                var login = new Login();
                Session["Login"] = login;
                return (Login)Session["Login"];
            }
        }
    }
}