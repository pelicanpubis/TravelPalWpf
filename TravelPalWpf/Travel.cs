namespace TravelPalWpf
{
    public class Travel
    {
        //properties som beskriver travel objektet som destination, antal resande, packlista, osv.
        public string Destination { get; set; }
        public Country Country { get; set; }
        public int Travellers { get; set; }

        public KindOfTrip KindOfTrip { get; set; }

        public string MeetingDetails { get; set; }


        //public List<PackingListItem> PackingList { get; set; }




        //Konstruktor  för att skapa och initialisera ett Travel-objekt, initaliserar propertiesarna.

        public Travel(string destination, Country country, int travellers, KindOfTrip kindOfTrip, string meetingDetails)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
            KindOfTrip = kindOfTrip;
            MeetingDetails = meetingDetails;


            // PackingList = packingList;
        }

        public Travel()
        {

        }


        //en metod som retunerar en sträng av info om resan
        public virtual string GetInfo()
        {



            return "Destination: " + Destination + "\n" +
                   "Country: " + Country + "\n" +
                   "Number of Travellers: " + Travellers + "\n" + "Kind of Trip: " + KindOfTrip + "\n";
        }

    }
}
