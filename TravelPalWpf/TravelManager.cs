using System.Collections.Generic;

namespace TravelPalWpf
{
    public static class TravelManager //ska denna klassen ha en konstruktor
    {
        //Properties: en property som är en lista, den håller olika travel objekt

        public static List<Travel> Travels { get; set; } = new(); // sätta den till new?





        //en metod som lägger till ett Travel objekt i Travels Listan. 

        public static void AddTravel(Travel travel)
        {
            Travels.Add(travel);

        }

        //en metod som tar bort ett travel objekt från Travels listan

        public static void RemoveTravel(Travel travel)
        {
            Travels.Remove(travel);
        }
    }
}
