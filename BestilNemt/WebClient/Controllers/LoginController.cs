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
            if (login != null)
            {
                login = proxy.Login(login);
                if (login != null)
                {
                    // var login = (Login)Session["Login"];
                    Session["Login"] = login;
                    if (!string.IsNullOrEmpty(login.Username))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Login");
                    }
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            //  return RedirectToAction("Index", "Home");

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
    }
}