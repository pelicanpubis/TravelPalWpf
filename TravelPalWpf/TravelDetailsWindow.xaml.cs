using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow()
        {
            InitializeComponent();





            // Initialize the variables
            string destinationCountryText = "";
            string travellers = txtTravellers.Text;
            string city = txtCity.Text;
            string kindOfTrip = "";



            // Check which user is logged in
            User signedInUser = (User)UserManager.SignedInUser;

            //// Hämta dens resor
            List<Travel> Travels = signedInUser.Travels;

            //lägger till användarens resor i list view
            foreach (Travel travel in Travels)
            {
                ListViewItem item = new ListViewItem();

                city = travel.Destination;
                travellers = travel.Travellers.ToString();
                kindOfTrip = travel.KindOfTrip.ToString();

                destinationCountryText += travel.Country;

            }

            txtCity.Text = city;
            txtDestinationCountry.Text = destinationCountryText;
            txtTravellers.Text = travellers;
            txtKindOfTrip.Text = kindOfTrip;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new();


            travelsWindow.Show();
            Close();
        }
    }
}
