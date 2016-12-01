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

            return View();
        }
        public ActionResult Signdo(Login login)
        {
            var proxy = new BestilNemtServiceClient();
            // Get the login object from the Session
            if (login == null) return RedirectToAction("Index", "Home");
            login = proxy.Login(login);
            // Login is now null if the username and password not match
            if (login == null) return RedirectToAction("Index", "Login");
            // Save the new login object to session
            Session["Login"] = login;
            // Redirect to Home if Username is null or empty, else to Login
            return RedirectToAction("Index", !string.IsNullOrEmpty(login.Username) ? "Home" : "Login");
        }

        public ActionResult CreateLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer, Login login)
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
        public ActionResult LogAf(Login login)
        {
            var proxy = new BestilNemtServiceClient();
            Session["Login"] = login;
            if(login != null)
            {
                var login2 = new Login();
            }

            return View(); 
        }
    }
}