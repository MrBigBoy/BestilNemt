using System;
using System.Collections.Generic;
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

            return View();
        }
        public ActionResult Signdo(Login login)
        {
            var proxy = new BestilNemtServiceClient();
            // Get the login object from the Session
            if (login == null)
                return RedirectToAction("Index", "Home");
            login = proxy.Login(login);
            // Login is now null if the username and password not match
            if (login == null)
                return RedirectToAction("Index", "Login");
            // Save the new login object to session
            Session["Login"] = login;
            // Save the person to the cart
            var personId = login.PersonId;
            var cart = (Cart)Session["ShoppingCart"];
            if (personId == 0)
                return RedirectToAction("Index", !string.IsNullOrEmpty(login.Username) ? "Home" : "Login");
            cart.PersonId = personId;
            Session["ShoppingCart"] = cart;
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
            if (customer.Name == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Du mangler at tilføje navn'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            if (customer.Address == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Du mangler at tilføje adresse'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            //if (!DateTime.TryParseExact("customer.Birthday", "MM/dd/yyyy", null, DateTimeStyles.None, out dt) == true)
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Syntax fejl ved fødselsdatoen f.ek.s 10/21/2012'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            //}
            if (customer.Email.Length < 6)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Email Min. 6 bogstaver'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            //if (!customer.Email.Contains("@") && customer.Email.Contains("."))
            //{
            //    return Content("<script language='javascript' type='text/javascript'>alert('Syntax fejl ved fødselsdatoen f.ek.s 10/21/2012'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            //}
            if (login.Password.Length < 6)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Kodeord Min. 6 cifre'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }

            else
            {
                proxy.AddCustomerWithLogin(customer, login);
                return RedirectToAction("Index");
            }
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
        public Cart ShoppingCart
        {
            get
            {
                if (Session["ShoppingCart"] != null)
                    return (Cart)Session["ShoppingCart"];
                var cart = new Cart { PartOrders = new List<PartOrder>() };
                Session["ShoppingCart"] = cart;
                return (Cart)Session["ShoppingCart"];
            }
        }
        public ActionResult LogOff()
        {

            var loginObj = new Login();
            Session["Login"] = loginObj;
            ShoppingCart.PartOrders = new List<PartOrder>();

            return RedirectToAction("Index");
        }
        private bool ValidatePersonInput(Customer customer)
        {
            try
            {
                return customer != null && !customer.Address.Equals("") && !customer.Name.Equals("") &&
               customer.Name != null && !customer.Address.Equals("") && customer.Address != null &&
               !customer.Email.Equals("") && customer.Email != null;
            }
            catch (Exception)
            {
                throw new Exception("");

            }

        }

    }
}