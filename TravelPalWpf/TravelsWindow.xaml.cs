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

            //visar användarens användarnamn
            txtLoggedInUser.Text = signedInUser.Username;

            //// Hämta dens resor
            List<Travel> Travels = signedInUser.Travels;



            //// Lägg till dens resor i ListView:en



            foreach (Travel travel in Travels)
            {
                ListViewItem item = new ListViewItem();
                item.Content = travel.GetInfo();
                lstTravels.Items.Add(item);
            }









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

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {

            //skapar en användare
            User signedInUser = (User)UserManager.SignedInUser;

            //hämtar det valde objektet från listboxen
            ListBoxItem selectedItem = (ListBoxItem)lstTravels.SelectedItem;

            Travel selectedTravel = (Travel)selectedItem.Tag;

            //tar bort det valda objetet från användaren lista av resor
            signedInUser.Travels.Remove(selectedTravel);

            //tar bort objektet från listviewn
            lstTravels.Items.Remove(selectedItem);

        }
    }
}




