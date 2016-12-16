using System;
using System.Collections.Generic;
using System.Web.Mvc;
using WebClient.BestilNemtServiceRef;

namespace WebClient.Controllers
{
    /// <summary>
    /// This controller is used to all Login related controls
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// The Index redirect to the signIn page
        /// </summary>
        /// <returns>
        /// The SignIn page
        /// </returns>
        public ActionResult Index()
        {
            return RedirectToAction("SignIn", "Login");
        }

        /// <summary>
        /// The sign page is used to sign a person in to the system
        /// </summary>
        /// <returns>
        /// Return the SignIn View
        /// </returns>
        public ActionResult SignIn()
        {
            return View();
        }

        /// <summary>
        /// This method is used to login
        /// </summary>
        /// <param name="login"></param>
        /// <returns>
        /// View of Homepage if not logged in, else Home of Login
        /// </returns>
        public ActionResult Signdo(Login login)
        {
            var proxy = new BestilNemtServiceClient();
            // If There is no login object, redirect to frontpage
            if (login == null)
                return RedirectToAction("Index", "Home");
            // Login with the login object, return null if login failed, else a login object with a personId
            login = proxy.Login(login);
            // Login is now null if the username and password not match
            if (login == null)
                return RedirectToAction("Index", "Login");
            // Save the new login object to session
            Session["Login"] = login;
            // Save the person to the cart
            var personId = login.PersonId;
            // Get the Cart from Session
            var cart = (Cart)Session["ShoppingCart"];
            // If the personId somehow is 0 and not set now, redirect to Login Home
            if (personId == 0)
                return RedirectToAction("Index", !string.IsNullOrEmpty(login.Username) ? "Home" : "Login");
            // Set the personId to the Cart
            cart.PersonId = personId;
            // Save the cart to the Session
            Session["ShoppingCart"] = cart;
            // Redirect to Home if Username is null or empty, else to Login
            return RedirectToAction("Index", !string.IsNullOrEmpty(login.Username) ? "Home" : "Login");
        }

        /// <summary>
        /// Method used to Create a Login
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateLogin()
        {
            return View();
        }

        /// <summary>
        /// Method used to Create a Customer with a login
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="login"></param>
        /// <returns>
        /// The View of the Índex if create was successfull, else reload the page
        /// </returns>
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer, Login login)
        {
            var proxy = new BestilNemtServiceClient();
            // Set the Username to the email for the Customer
            login.Username = customer.Email;
            // Alert if the Customer name is null
            if (string.IsNullOrEmpty(customer.Name) || customer.Name.Length < 4)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Du mangler at tilføje navn, navnet skal være fornavn og efternavn'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            // Alert if the Customer address is null
            if (string.IsNullOrEmpty(customer.Address) || customer.Address.Length < 4)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Du mangler at tilføje valid adresse'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            // Alert if the Customer email is under 6 digit
            if (string.IsNullOrEmpty(customer.Email) || customer.Email.Length < 6)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Email Min. 6 bogstaver'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            var dateTime = Convert.ToDateTime(customer.Birthday);
            if (dateTime == new DateTime(0001, 01, 01, 00, 00, 00))
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Dato ikke korrekt, skal skrives i følgende format: dd-mm-yyyy'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            // Alert if the Customer password is under 6 digit
            if (string.IsNullOrEmpty(login.Password) || login.Password.Length < 6)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('Kodeord Min. 6 cifre'); window.location.replace('http://localhost:50483/Login/CreateLogin');</script>");
            }
            // Add the Customer with the login object
            proxy.AddCustomerWithLogin(customer, login);
            // Reload to Index
            return Content("<script language='javascript' type='text/javascript'>alert('Bruger tilføjet'); window.location.replace('http://localhost:50483');</script>");
        }

        /// <summary>
        /// This page is used to Reset a Login
        /// </summary>
        /// <returns></returns>
        public ActionResult ResetLogin()
        {
            var login = Login;
            return View(login);
        }

        /// <summary>
        /// This page is used to get the Login from Session
        /// </summary>
        public Login Login
        {
            get
            {
                // Get the Login from Session
                var login = (Login)Session["Login"];
                // If the Login is allreade set return it
                if (login != null)
                    return login;
                // Create the login
                login = new Login();
                // Set the login to Session
                Session["Login"] = login;
                return login;
            }
        }

        /// <summary>
        /// This method is used to get the ShoppingCart
        /// </summary>
        public Cart ShoppingCart
        {
            get
            {
                // Get the Cart from Session
                var cart = (Cart)Session["ShoppingCart"];
                // If the Cart is already set, return it
                if (cart != null)
                    return cart;
                // Create the cart
                cart = new Cart();
                // Set the cart to Session
                Session["ShoppingCart"] = cart;
                return cart;
            }
        }

        /// <summary>
        /// This method is used to log off
        /// </summary>
        /// <returns>
        /// Index 
        /// </returns>
        public ActionResult LogOff()
        {
            // Clear the login object from Session
            var loginObj = new Login();
            Session["Login"] = loginObj;
            // Clear the shoppingCart
            ShoppingCart.PartOrders = new List<PartOrder>();
            return RedirectToAction("Index");
        }
    }
}