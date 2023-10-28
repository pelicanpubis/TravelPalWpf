using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;


namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for TravelsWindow.xaml
    /// </summary>
    public partial class TravelsWindow : Window
    {

        // static List<Travel> Travels = new();
        public TravelsWindow()
        {
            InitializeComponent();


            //// Kolla vilken användare som är inloggad
            User signedInUser = (User)UserManager.SignedInUser;

            //// Hämta dens resor
            List<Travel> Travels = signedInUser.Travels;

            // List<Travel> userTravels = signedInUser.Travels;


            //// Lägg till dens resor i ListView:en





            foreach (Travel travel in Travels)
            {
                ListViewItem item = new ListViewItem();
                item.Content = travel.GetInfo();
                lstTravels.Items.Add(item);
            }



            //  lstTravels.ItemsSource = userTravels;


            // lstTravels.ItemsSource = Travels;

            // lstTravels.Items.Add(Travels);







        }

        private void lstTravels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddTravel_Click(object sender, RoutedEventArgs e)
        {

            AddTravelWindow addTravelWindow = new();
            addTravelWindow.Show();
            Close();

        }




    }
}




