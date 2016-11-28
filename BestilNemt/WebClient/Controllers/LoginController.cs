using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

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
            return View(login);
        }

        public ActionResult CreateLogin()
        {
            var login = Login;
            return View(login);
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
                if (Session["Login"] != null) return (Login) Session["Login"];
                var login = new Login();
                Session["Login"] = login;
                return (Login) Session["Login"];
            }
        }
    }
}