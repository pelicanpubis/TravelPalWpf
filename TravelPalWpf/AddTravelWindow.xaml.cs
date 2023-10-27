﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace TravelPalWpf
{
    /// <summary>
    /// Interaction logic for AddTravelWindow.xaml
    /// </summary>
    public partial class AddTravelWindow : Window
    {
        static List<Travel> Travels = new List<Travel>(); //skapar en ny listA?
        public AddTravelWindow()
        {
            InitializeComponent();

            //Loopa över alla enums

            cbCountry.Items.Add("- - Select Prio - - "); //lägger till en label i comboboxen
            cbCountry.SelectedIndex = 0;


            foreach (Country country in System.Enum.GetValues(typeof(Country)))  //loopar genon enums

            {

                /* cbPrios.Items.Add(Priority.ToString()); *///för varje gång man loopar genum sina enums så lägger man till items i comboboxen
                ListViewItem item = new(); //gör en ny klass //lagt till en
                item.Content = country.ToString(); //content är det som kommer att synas i combo boxen
                item.Tag = country;   //tag är en property med setter och getter

                cbCountry.Items.Add(item);


            }



            cbCountry.SelectedIndex = 0;


            //Lägg till i comboboxem

        }



        private void lstTravelList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Kolla om alla fält är rätt ifyllda
            // Om dom är det...

            // Skapa en ny Vaction / Worktrip
            // Lägg till den resan till den inloggade användarens resor

            // Om dom INTE är det
            // Visa en varningsruta
        }
    }
}
