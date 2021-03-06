﻿using System.Windows;
using WPF_Client.BestilNemtWPF;

namespace WPF_Client
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private readonly BestilNemtServiceClient proxy = new BestilNemtServiceClient();
        //public Login Login2 { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            LoginManager.Setup(proxy);

        }

        /// <summary>
        /// Logs the user in if the login information is correct,
        /// and shows a message box if the information is incorrect and lets the user try again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginConfirm_Click(object sender, RoutedEventArgs e)
        {
            GetLogin();
        }
        public Login GetLogin()
        {
            var login = LoginManager.Login(UsernameField.Text, PasswordField.Password);
            if (login != null)
            {

                var personId = login.PersonId;
                //Check the database to see if the person is a admin, and returns a admin object
                var admin = proxy.GetAdmin(personId);
                //Uses the admin object to login

                if (admin != null)
                {
                    //Creates a new MainWindow and shows it to the user
                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    //Closes the login form
                    Close();
                }
                else
                {
                    //If the person who logsin is not an admin, then it return this box, to say the person can't use the program
                    MessageBox.Show("Du er ikke en administrator, du har ikke lov til at bruge dette program");
                }
            }
            else
            {
                MessageBox.Show("Dit login virkede ikke, prøv igen");
            }
            return login;
        }
    }
}


