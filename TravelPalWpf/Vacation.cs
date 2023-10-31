namespace TravelPalWpf
{
    public class Vacation : Travel
    {
        //en bool property som ska bestämma om en resa är all inclusive
        public bool AllInclusive { get; set; }



        //konstruktor

        public Vacation(string destination, Country country, int travellers, bool allInclusive, KindOfTrip kindOfTrip, string meetingDetails)
            : base(destination, country, travellers, kindOfTrip, meetingDetails)
        {
            AllInclusive = allInclusive;
            //behöver jag sett:a resten av properties?

        }

        public Vacation()
        {

        }

        //metod som förmodligen ska retunera en sträng och printa ut all info om resan
        public override string GetInfo()
        {


            return $"{Country}";
        }
    }
}
