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



            //kolla vilken användare som är inne
            if (UserManager.SignedInUser is User signedInUser)
            {
                //visar User användarens namn i text box
                txtLoggedInUser.Text = signedInUser.Username;

                // Check if the user is new (doesn't have any travels)
                if (signedInUser.Travels != null && signedInUser.Travels.Count > 0)
                {
                    foreach (Travel travel in signedInUser.Travels)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Content = travel.GetInfo();
                        item.Tag = travel;
                        lstTravels.Items.Add(item);
                    }
                }


                //hämtar dens resor
                List<Travel> travels = signedInUser.Travels;


                //lägger till resor i listview
                //foreach (Travel travel in travels)
                //{
                //    ListViewItem item = new ListViewItem();
                //    item.Content = travel.GetInfo();
                //    item.Tag = travel;
                //    lstTravels.Items.Add(item);
                //}
            }//om det är admin som är inloggad:
            else if (UserManager.SignedInUser is Admin signedInAdmin)
            {
                // Code for a signed-in Admin
                txtLoggedInUser.Text = signedInAdmin.Username;

                //hämtar dens resor
                List<Travel> travels = signedInAdmin.Travels;

                //lägger till resor i listview
                foreach (Travel travel in travels)
                {
                    ListViewItem item = new ListViewItem();
                    item.Content = travel.GetInfo();

                    item.Tag = travel;
                    lstTravels.Items.Add(item);
                }
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

                if (lstTravels.SelectedItem != null)
                {
                    ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;
                    Travel selectedTravel = (Travel)selectedItem.Tag;

                    // Remove the travel from the signed-in user's travels
                    if (UserManager.SignedInUser is User signedInUser)
                    {
                        signedInUser.Travels.Remove(selectedTravel);
                    }

                    // Remove the item from the list view
                    lstTravels.Items.Remove(selectedItem);
                }

                else
                {


                    MessageBox.Show("Please select a travel from the list before clicking 'Remove'.");

                }




                ////om användaren inte har valt en resa att radera men inte valt någonting
                //if (lstTravels != null)

                //{
                //    ListViewItem selectedItem = (ListViewItem)lstTravels.SelectedItem;
                //    if (selectedItem != null)
                //    {
                //        Travel selectedTravel = (Travel)selectedItem.Tag;

                //        //skapar användare
                //        User signedInUser = UserManager.SignedInUser as User;
                //        //tar bort användarens resa från reselistan
                //        signedInUser.Travels.Remove(selectedTravel);
                //        //tar bort resan från listview
                //        lstTravels.Items.Remove(selectedItem);
                //    }

                //    else
                //    {


                //        MessageBox.Show("Please select a travel from the list before clicking 'Remove'.");

                //    }

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

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {

            string travelPalInfo = @"
           - Add, remove, and view trip details.
           - Easily identify all-inclusive vacations.
           - Organize work trips with meeting details.";
            MessageBox.Show(travelPalInfo);



        }
    }
}




