using System.Collections.Generic;

namespace TravelPalWpf
{


    public class User : IUser
    {
        public string Username { get; set; } // required?
        public string Password { get; set; }
        public Country Location { get; set; }
        public List<Travel> Travels { get; set; }

        //Konstruktor
        //när en instans av USER skapas så skapas en tom travelslista

        public User(string username, string password, Country location) //behövs denna?
        {

            Username = username;
            Password = password;
            Location = location;
            //Travels = new List<Travel>(); //behöver man sätta listan i construktorn?


        }
    }

}
