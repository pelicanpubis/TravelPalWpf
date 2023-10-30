﻿using System.Windows;

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

                ///* cbPrios.Items.Add(Priority.ToString()); *///för varje gång man loopar genum sina enums så lägger man till items i comboboxen
                //ListViewItem item = new(); //gör en ny klass //lagt till en
                //item.Content = country.ToString(); //content är det som kommer att synas i combo boxen
                //item.Tag = country;   //tag är en property med setter och getter

                cbCountry.Items.Add(country);




            }



            cbCountry.SelectedIndex = 0;
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            // TODO: Refactor these to clear UI method
            warnUsername.Visibility = Visibility.Hidden;
            warnPassword.Visibility = Visibility.Hidden;

            // Läsa våra inputs
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password.Trim();
            Country selectedCountryItem = (Country)cbCountry.SelectedItem;

            // Checka alla inputs
            if (username == "")
            {
                warnUsername.Visibility = Visibility.Visible;
            }

            if (password == "")
            {
                warnPassword.Visibility = Visibility.Visible;
            }

            if (username != "" && password != "" && selectedCountryItem != 0)
            {
                // Skapa en user
                //  User newUser = new User(username, password);

                User newUser = UserManager.RegisterUser(username, password, selectedCountryItem);






                MainWindow mainWindow = new();
                mainWindow.Show();
                Close();

            }
        }
    }
}
