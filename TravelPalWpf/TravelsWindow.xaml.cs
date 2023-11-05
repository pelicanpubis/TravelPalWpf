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



            }//om det är admin som är inloggad:
            else if (UserManager.SignedInUser is Admin signedInAdmin)
            {
                // Code for a signed-in Admin
                txtLoggedInUser.Text = signedInAdmin.Username;

                btnAddTravel.IsEnabled = false;

                // Retrieve all users' travels for the admin
                List<Travel> adminTravels = new List<Travel>();

                adminTravels = UserManager.GetAllUsersTravels();

                // Populate the lstTravels ListView with the retrieved data
                foreach (Travel travel in adminTravels)
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

                    if (UserManager.SignedInUser is User)
                    {
                        // Ta bort resan från sig själv

                        User user = UserManager.SignedInUser as User;
                        user.Travels.Remove(selectedTravel);
                    }
                    else if (UserManager.SignedInUser is Admin)
                    {
                        // Ta bort resan från rätt user

                        foreach (var u in UserManager.Users)
                        {
                            if (u is User)
                            {
                                User user = (User)u;

                                if (user.Travels.Contains(selectedTravel))
                                {
                                    // Ta bort resan från "backend:en"
                                    user.Travels.Remove(selectedTravel);
                                    break;
                                }
                            }
                        }
                    }

                    // Ta bort resan från UI:t
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
            // checkar ett objekt är markerat i listan (lstTravels)
            if (lstTravels.SelectedItem != null)
            {

                ListViewItem? selectedItem = lstTravels.SelectedItem as ListViewItem; // Hämta det markerade objektet som en ListViewItem
                Travel? selectedTravel = selectedItem!.Tag as Travel;// Hämta resan som är associerad med det markerade objektet
                TravelDetailsWindow travelDetailsWindow = new(selectedTravel);  // Skapa ett nytt fönster (TravelDetailsWindow) för att visa detaljer om den valda resan
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
            UserManager.SignOutUser();
            Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {

            string travelPalInfo = @"
           - Add, remove, and view trip details.
           - Easily identify all-inclusive vacations.
           - Organize work trips with meeting details.";
            // MessageBox.Show(travelPalInfo);

            // Create a custom window with a title
            Window infoWindow = new Window
            {
                Title = "Travel Info", // Titlen på fönstret
                Content = new TextBlock { Text = travelPalInfo }, // lägger string info
                Width = 300,
                Height = 200,
                ResizeMode = ResizeMode.NoResize, // Íngen resizing
                WindowStartupLocation = WindowStartupLocation.CenterScreen // Centrerar fönstret
            };

            infoWindow.ShowDialog();

            // string travelPalInfo = @"
            //- Add, remove, and view trip details.
            //- Easily identify all-inclusive vacations.
            //- Organize work trips with meeting details.";
            //  MessageBox.Show(travelPalInfo);


        }
    }
}






