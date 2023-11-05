using System;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {

        public AddTravelWindow()
        {
            InitializeComponent();

            //Loopa över alla enums
            cbCountry.Items.Add("- - Select Country - - "); //lägger till en label i comboboxen
            cbCountry.SelectedIndex = 0;

            foreach (Country country in System.Enum.GetValues(typeof(Country)))  //loopar genon enums

            {
                cbCountry.Items.Add(country);
            }

            cbCountry.SelectedIndex = 0;


            //Lägg till i comboboxem
            //Loopa över alla enums
            cbKindOfTrip.SelectedIndex = 0;

            foreach (KindOfTrip kindOfTrip in System.Enum.GetValues(typeof(KindOfTrip)))  //loopar genon enums
            {
                cbKindOfTrip.Items.Add(kindOfTrip);

            }

            cbKindOfTrip.SelectedIndex = 0;
        }



        private void lstTravelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                // Kolla om alla fält är rätt ifyllda
                if (txtCity.Text == "" && txtTravellers.Text == "")
                {
                    //Visa varningsmeddelande
                    MessageBox.Show("Please type in correct");  //message box är en class
                }
                else if (cbCountry.SelectedIndex == 0 && cbKindOfTrip.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select a country and a type of trip");
                }
                else
                {

                    //// Skapa en ny Vaction / Worktrip
                    /// //hämtar text från text box
                    string city = txtCity.Text;
                    string travellers = txtTravellers.Text;
                    string meetingDetails = txtMeetingDetails.Text;
                    bool allInclusive = chkAllInclusive.IsChecked == true;

                    //hämtar text från combobox Country
                    Country selectedCountryItem = (Country)cbCountry.SelectedItem;  //breakar här
                    string country = selectedCountryItem.ToString();

                    //hämtar text från combo box kind of trip
                    KindOfTrip selectedkindoftripitem = (KindOfTrip)cbKindOfTrip.SelectedItem;
                    string kindoftrip = selectedkindoftripitem.ToString();




                    // HAr vi valt Vacation eller work trip?
                    // Kolla vilket element som är selectat i ComboBoxen
                    if (kindoftrip != null && selectedkindoftripitem.ToString() == "Vacation")

                    {
                        // Om vi har valt vacation -> new Vacation(); gör två stycke, om en är all inclusive sätt den till true, om inte sätt den till false
                        Vacation newVacation = new Vacation(city, Enum.Parse<Country>(country), int.Parse(travellers), allInclusive, Enum.Parse<KindOfTrip>(kindoftrip), meetingDetails);
                        txtCity.Text = city;
                        txtTravellers.Text = travellers;
                        cbKindOfTrip.Text = kindoftrip;

                        if (UserManager.SignedInUser is User signedInUser)

                        {
                            signedInUser.Travels.Add(newVacation);


                            TravelsWindow travelsWindow = new();
                            travelsWindow.Show();
                            Close();



                        }


                    }

                    // Om vi har valt work trip -> new WorkTrip();

                    else if (kindoftrip != null && selectedkindoftripitem.ToString() == "WorkTrip")
                    {
                        WorkTrip newWorktrip = new WorkTrip(city, Enum.Parse<Country>(country), int.Parse(travellers), meetingDetails, Enum.Parse<KindOfTrip>(kindoftrip));
                        txtCity.Text = city;
                        txtTravellers.Text = travellers;
                        cbKindOfTrip.Text = kindoftrip;


                        if (UserManager.SignedInUser is User signedInUser)

                        {

                            signedInUser.Travels.Add(newWorktrip);
                            TravelsWindow travelsWindow = new();
                            travelsWindow.Show();
                            Close();

                        }

                    }
                }


                //TravelsWindow travelsWindow = new();
                //travelsWindow.Show();
                // Close();

            }

            catch (FormatException)
            {
                MessageBox.Show("Please enter a number as a character for travelers.");
                return; // Exit the method early to prevent further processing
            }



        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {

            TravelsWindow travelsWindow = new();
            travelsWindow.Show();
            Close();

        }

        private void cbKindOfTrip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Kollar vilket item som är selectat i combo boxen.
            var selectedItem = (KindOfTrip)cbKindOfTrip.SelectedItem;

            //om det selectade itemet är en work trip
            if (selectedItem == KindOfTrip.WorkTrip)
            {
                //sätter allinclusive boxen till hidden men visar resten
                chkAllInclusive.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Visible;
                lblMeetingDetails.Visibility = Visibility.Visible;
            }
            else if (selectedItem == KindOfTrip.Vacation)
            {
                chkAllInclusive.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Collapsed;
                lblMeetingDetails.Visibility = Visibility.Collapsed;

            }
        }
    }
}




