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


            ////om användaren är typen User
            //if (UserManager.SignedInUser!.GetType() == typeof(User))
            //{

            //    User signedInClient = (User)UserManager.SignedInUser;

            //    //sätter text box till logged in users
            //    txtLoggedInUser.Text = signedInClient.Username;

            //    //List<Travel> Travels = signedInClient.Travels;



            //    if (signedInClient.Travels.Count == 0)
            //    {


            //        //skapa två default resor:
            //        Travel defaultTravelOne = new Travel("Malmö", Country.Sweden, 1, KindOfTrip.WorkTrip, "work");
            //        Travel defaultTravelTwo = new Travel("Köpenhamn", Country.Denmark, 1, KindOfTrip.Vacation, "vacation");



            //        //Skapar listviewitem för första default resan:
            //        ListViewItem item1 = new ListViewItem();
            //        item1.Content = defaultTravelOne.GetInfo();
            //        item1.Tag = defaultTravelOne;
            //        lstTravels.Items.Add(item1);


            //        // Skapar ListViewItem för andra default resan:
            //        ListViewItem item2 = new ListViewItem();
            //        item2.Content = defaultTravelTwo.GetInfo();
            //        item2.Tag = defaultTravelTwo;
            //        lstTravels.Items.Add(item2);


            //        foreach (Travel travel in TravelManager.Travels)
            //        {
            //            ListViewItem item = new ListViewItem();
            //            item.Content = travel.GetInfo();
            //            item.Tag = travel;
            //            lstTravels.Items.Add(item);
            //        }

            //    }



            //    //testa lägg in default resorna här
            //}
            //else if (UserManager.SignedInUser is Admin)

            //{
            //    Admin signedInClient = (Admin)UserManager.SignedInUser;

            //    txtLoggedInUser.Text = signedInClient.Username;


            //    if (UserManager.SignedInUser is Admin)
            //    {


            //        //skapa två default resor:
            //        Travel defaultTravelOne = new Travel("Malmö", Country.Sweden, 1, KindOfTrip.WorkTrip, "work");
            //        Travel defaultTravelTwo = new Travel("Köpenhamn", Country.Denmark, 1, KindOfTrip.Vacation, "vacation");



            //        //Skapar listviewitem för första default resan:
            //        ListViewItem item1 = new ListViewItem();
            //        item1.Content = defaultTravelOne.GetInfo();
            //        item1.Tag = defaultTravelOne;
            //        lstTravels.Items.Add(item1);


            //        // Skapar ListViewItem för andra default resan:
            //        ListViewItem item2 = new ListViewItem();
            //        item2.Content = defaultTravelTwo.GetInfo();
            //        item2.Tag = defaultTravelTwo;
            //        lstTravels.Items.Add(item2);


            //        foreach (Travel travel in TravelManager.Travels)
            //        {
            //            ListViewItem item = new ListViewItem();
            //            item.Content = travel.GetInfo();
            //            item.Tag = travel;
            //            lstTravels.Items.Add(item);
            //        }




            //    }

            //}






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

            //skapa två default resor:
            Travel defaultTravelOne = new Travel("Malmö", Country.Sweden, 1, KindOfTrip.WorkTrip, "work");
            Travel defaultTravelTwo = new Travel("Köpenhamn", Country.Denmark, 1, KindOfTrip.Vacation, "vacation");

            //Skapar listviewitem för första default resan:
            ListViewItem item1 = new ListViewItem();
            item1.Content = defaultTravelOne.GetInfo();
            item1.Tag = defaultTravelOne;
            lstTravels.Items.Add(item1);


            // Skapar ListViewItem för andra default resan:
            ListViewItem item2 = new ListViewItem();
            item2.Content = defaultTravelTwo.GetInfo();
            item2.Tag = defaultTravelTwo;
            lstTravels.Items.Add(item2);




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




