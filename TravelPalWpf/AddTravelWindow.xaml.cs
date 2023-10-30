﻿using System;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        //static List<Travel> Travels = new List<Travel>(); //skapar en ny listA?
        //  private List<Travel> Travels = new List<Travel>();

        public AddTravelWindow()
        {
            InitializeComponent();

            //Loopa över alla enums

            cbCountry.Items.Add("- - Select Country - - "); //lägger till en label i comboboxen
            cbCountry.SelectedIndex = 0;


            foreach (Country country in System.Enum.GetValues(typeof(Country)))  //loopar genon enums

            {

                ///* cbPrios.Items.Add(Priority.ToString()); *///för varje gång man loopar genum sina enums så lägger man till items i comboboxen
                //ListViewItem item = new(); //gör en ny klass //lagt till en
                //item.Content = country.ToString(); //content är det som kommer att synas i combo boxen
                //item.Tag = country;   //tag är en property med setter och getter

                cbCountry.Items.Add(country);




            }



            cbCountry.SelectedIndex = 0;


            //Lägg till i comboboxem
            //Loopa över alla enums

            cbKindOfTrip.SelectedIndex = 0;


            foreach (KindOfTrip kindOfTrip in System.Enum.GetValues(typeof(KindOfTrip)))  //loopar genon enums
            {
                cbKindOfTrip.Items.Add(kindOfTrip);

                ///* cbPrios.Items.Add(Priority.ToString()); *///för varje gång man loopar genum sina enums så lägger man till items i comboboxen
                //ListViewItem item = new(); //gör en ny klass //lagt till en
                //item.Content = kindOfTrip.ToString(); //content är det som kommer att synas i combo boxen
                //item.Tag = kindOfTrip;   //tag är en property med setter och getter

                //cbKindOfTrip.Items.Add(item);
            }

            cbKindOfTrip.SelectedIndex = 0;
        }



        private void lstTravelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Kolla om alla fält är rätt ifyllda

            if (txtCity.Text == "" && txtTravellers.Text == "")
            {
                //Visa varningsmeddelande
                MessageBox.Show("Please type in correct");  //message box är en class
            }
            else if (cbCountry.SelectedIndex == 0 && cbKindOfTrip.SelectedIndex == 0) //ska man kanske ha eller operator?
            {
                MessageBox.Show("Please select a country and a type of trip");
            }
            else
            {
                //// Skapa en ny Vaction / Worktrip
                /// //hämtar text från text box
                string city = txtCity.Text;
                string travellers = txtTravellers.Text;

                //hämtar text från combobox Country
                Country selectedCountryItem = (Country)cbCountry.SelectedItem;
                string country = selectedCountryItem.ToString();

                //hämtar text från combo box kind of trip
                KindOfTrip selectedkindoftripitem = (KindOfTrip)cbKindOfTrip.SelectedItem;
                string kindoftrip = selectedkindoftripitem.ToString();




                // HAr vi valt Vacation eller work trip?

                // Om vi har valt vacation -> new Vacation();
                // Om vi har valt work trip -> new WorkTrip();

                // Lägg till vår nya vacation / work trip till den inloggade userns resor


                //Skapar ett nytt travelobjekt
                Travel newTravel = new Travel(city, Enum.Parse<Country>(country), int.Parse(travellers), Enum.Parse<KindOfTrip>(kindoftrip));


                // Lägg till den resan till den inloggade användarens resor
                User signedInUser = (User)UserManager.SignedInUser;







                //lägger till travel i listan
                //  Travels.Add(newTravel);
                signedInUser.Travels.Add(newTravel);




                ////kanske ha en go back knapp till travel window?



                TravelsWindow travelsWindow = new();


                travelsWindow.Show();
                Close();




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
            var selectedItem = (KindOfTrip)cbKindOfTrip.SelectedItem;

            if (selectedItem == KindOfTrip.WorkTrip)
            {
                chkAllInclusive.Visibility = Visibility.Hidden;
                txtMeetingDetails.Visibility = Visibility.Visible;
            }
            else if (selectedItem == KindOfTrip.Vacation)
            {
                chkAllInclusive.Visibility = Visibility.Visible;
                txtMeetingDetails.Visibility = Visibility.Hidden;
            }
        }
    }
}



