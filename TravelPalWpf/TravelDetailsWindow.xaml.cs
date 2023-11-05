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

            // Fyller textfälten med information från objektet 'travelToShow'
            txtCity.Text = travelToShow.Destination;
            txtMeetingDetails.Text = travelToShow.MeetingDetails;
            txtDestinationCountry.Text = travelToShow.Country.ToString();
            txtTravellers.Text = travelToShow.Travellers.ToString();

            // Avgör resans typ och ställ in texten för 'txtKindOfTrip' därefter
            txtKindOfTrip.Text = travelToShow.GetType() == typeof(Vacation) ? "Vacation" : "Work Trip";


            // Om det är en "WorkTrip"
            if (txtKindOfTrip.Text == "Work Trip")
            {
                txtMeetingDetails.Visibility = Visibility.Visible;
                lblMeetingDetails.Visibility = Visibility.Visible;

            }

            // Om det inte är en "WorkTrip"
            else
            {
                //Gömmer meeting details textboxen
                txtMeetingDetails.Visibility = Visibility.Hidden;

            }

            if (txtKindOfTrip.Text == "Vacation")
            {
                chkAllInclusive.Visibility = Visibility.Visible;


                //checkar om 'travelToShow' är en "vacation" och om den är all-inclusive
                if (travelToShow is Vacation vacation && vacation.AllInclusive)
                {
                    //visar all inclusive checkboxen
                    chkAllInclusive.IsChecked = true;
                }
            }
            else
            {
                //annars gömmer den 
                chkAllInclusive.Visibility = Visibility.Hidden;
            }

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();
        }

        private void chkAllInclusive_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
