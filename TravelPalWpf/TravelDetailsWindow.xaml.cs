using System.Windows;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for TravelDetailsWindow.xaml
    /// </summary>
    public partial class TravelDetailsWindow : Window
    {
        public TravelDetailsWindow(Travel travelToShow)
        {
            InitializeComponent();





            // Initialize the variables
            //string destinationCountryText = "";
            //string travellers = txtTravellers.Text;
            //string city = txtCity.Text;
            //string kindOfTrip = "";



            //// Check which user is logged in
            //User signedInUser = (User)UserManager.SignedInUser;

            ////// Hämta dens resor
            //List<Travel> Travels = signedInUser.Travels;

            ////lägger till användarens resor i list view
            //foreach (Travel travel in Travels)
            //{
            //    ListViewItem item = new ListViewItem();

            //    city = travel.Destination;
            //    travellers = travel.Travellers.ToString();
            //    kindOfTrip = travel.KindOfTrip.ToString();

            //    destinationCountryText = travel.Country.ToString();
            //}

            txtCity.Text = travelToShow.Destination;
            txtDestinationCountry.Text = travelToShow.Country.ToString();
            txtTravellers.Text = travelToShow.Travellers.ToString();
            txtKindOfTrip.Text = travelToShow.GetType() == typeof(Vacation) ? "Vacation" : "Work Trip";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new();


            travelsWindow.Show();
            Close();
        }
    }
}
