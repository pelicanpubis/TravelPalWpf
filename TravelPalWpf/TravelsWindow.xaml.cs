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
                item.Tag = travel;
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

            //om användaren inte har valt en resa att radera men inte valt någonting
            if (lstTravels != null)

            {
                ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;
                if (selectedItem != null)
                {
                    Travel selectedTravel = (Travel)selectedItem.Tag;

                    //skapar användare
                    User signedInUser = UserManager.SignedInUser as User;
                    //tar bort användarens resa från reselistan
                    signedInUser.Travels.Remove(selectedTravel);
                    //tar bort resan från listview
                    lstTravels.Items.Remove(selectedItem);
                }

                else
                {


                    MessageBox.Show("Please select a travel from the list before clicking 'Remove'.");

                }

            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {

            if (lstTravels.SelectedItem != null)
            {
                ListViewItem? selectedItem = lstTravels.SelectedItem as ListViewItem;
                Travel? selectedTravel = selectedItem!.Tag as Travel;
                TravelDetailsWindow travelDetailsWindow = new(selectedTravel);
                travelDetailsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Please select a travel from the list before clicking 'Show Details'.");
            }





        }

        private void btnSignOut_Click(object sender, RoutedEventArgs e) //loggar inte riktigt ut, utan är mer en tillbaka knapp
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }
    }
}




