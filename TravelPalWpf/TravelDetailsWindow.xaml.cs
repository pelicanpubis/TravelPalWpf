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




            txtCity.Text = travelToShow.Destination;
            txtMeetingDetails.Text = travelToShow.MeetingDetails;
            txtDestinationCountry.Text = travelToShow.Country.ToString();
            txtTravellers.Text = travelToShow.Travellers.ToString();
            txtKindOfTrip.Text = travelToShow.GetType() == typeof(Vacation) ? "Vacation" : "Work Trip";

            if (txtKindOfTrip.Text == "Work Trip")
            {
                txtMeetingDetails.Visibility = Visibility.Visible;
                lblMeetingDetails.Visibility = Visibility.Visible;
                txtMeetingDetails.Text = travelToShow.MeetingDetails;

            }
            else
            {
                txtMeetingDetails.Visibility = Visibility.Hidden;

            }

            if (txtKindOfTrip.Text == "Vacation")
            {
                chkAllInclusive.Visibility = Visibility.Visible;


                //checkar om checkbox är true
                if (travelToShow is Vacation vacation && vacation.AllInclusive)
                {
                    chkAllInclusive.IsChecked = true;
                }
            }
            else
            {
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
