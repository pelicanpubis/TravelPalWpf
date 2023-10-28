using System.Windows;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Refactor these to clear UI method
            warnUsername.Visibility = Visibility.Hidden;
            warnPassword.Visibility = Visibility.Hidden;

            // Läsa våra inputs
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Checka alla inputs
            if (username == "")
            {
                warnUsername.Visibility = Visibility.Visible;
            }

            if (password == "")
            {
                warnPassword.Visibility = Visibility.Visible;
            }

            if (username != "" && password != "")
            {
                // Skapa en user
                //  User newUser = new User(username, password);

                User newUser = UserManager.RegisterUser(username, password);






                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();

            }
        }
    }
}
