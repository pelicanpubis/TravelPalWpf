using System;
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

            //Loopa över alla enums

            cbCountry.Items.Add("- - Select Country - - "); //lägger till en label i comboboxen
            cbCountry.SelectedIndex = 0;


            foreach (Country country in System.Enum.GetValues(typeof(Country)))  //loopar genon enums

            {

                cbCountry.Items.Add(country);
            }


            cbCountry.SelectedIndex = 0;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // TODO: Refactor these to clear UI method
                warnUsername.Visibility = Visibility.Hidden;
                warnPassword.Visibility = Visibility.Hidden;

                // Läsa våra inputs
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Password.Trim();
                Country selectedCountryItem = (Country)cbCountry.SelectedValue;


                //kollar med validateuser metoden om username är taget
                if (!UserManager.ValidateUsername(username))
                {
                    // Visar varningsrute om användar namn inte är taget
                    MessageBox.Show("Username is already taken. Please choose a different username.");
                    return;
                }

                // Checka alla inputs
                if (username == "")
                {
                    warnUsername.Visibility = Visibility.Visible;
                    return;
                }

                if (password == "")
                {
                    warnPassword.Visibility = Visibility.Visible;
                    return;
                }

                if (username != "" && password != "" && cbCountry.SelectedIndex != 0)
                {
                    // Skapa en user
                    //  User newUser = new User(username, password);

                    User newUser = UserManager.RegisterUser(username, password, selectedCountryItem);

                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    Close();

                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show("Please select a country");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong");
            }

        }
    }
}
