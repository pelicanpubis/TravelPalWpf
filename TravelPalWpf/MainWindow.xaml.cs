using System.Windows;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            // Läs innehållet i username och password-textrutorna

            string username = txtUsername.Text;
            string password = txtPassword.Password;

            // Använd UserManager för att testa logga in

            bool isSuccessfulSignIn = UserManager.SignInUser(username, password);

            if (isSuccessfulSignIn) // Lyckas inloggningen... Öppna AccountWindow!
            {
                TravelsWindow travelWindow = new();
                travelWindow.Show();
                Close();
            }
            else // Misslyckas inloggningen... Visa varningsmeddelande!
            {
                MessageBox.Show("Invalid username or password!", "Warning");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();


        }
    }
}
