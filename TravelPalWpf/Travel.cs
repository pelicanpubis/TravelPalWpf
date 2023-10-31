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

        //public DateTime StartDate { get; set; } nice to have
        //public DateTime EndDate { get; set; } nice to have
        //public int TravelDays { get; set; } nice to have



        //Konstruktor  för att skapa och initialisera ett Travel-objekt, initaliserar propertiesarna.

        public Travel(string destination, Country country, int travellers, KindOfTrip kindOfTrip, string meetingDetails)
        {
            Destination = destination;
            Country = country;
            Travellers = travellers;
            KindOfTrip = kindOfTrip;
            MeetingDetails = meetingDetails;
            //MeetingDetails = meetingDetails;

            // PackingList = packingList;
            //StartDate = startDate;
            //EndDate = endDate;
        }





        //en metod som retunerar en sträng av info om resan
        public virtual string GetInfo()
        {
            return "Destination: " + Destination + "\n" +
                   "Country: " + Country + "\n" +
                   "Number of Travellers: " + Travellers + "\n" + "Kind of Trip: " + KindOfTrip + "\n";
        }


        ////en mentod som kalkylerar traveldays
        //private int CalculateTravelDays()
        //{
        //    TimeSpan travelDuration = EndDate - StartDate;
        //    return travelDuration.Days;
        //}
    }
}
