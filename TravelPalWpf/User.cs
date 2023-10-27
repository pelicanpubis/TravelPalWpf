using System.Collections.Generic;

namespace TravelPalWpf
{


    public class User : IUser
    {
        public string Username { get; set; } //eller string?
        public string Password { get; set; }
        public Country Location { get; set; }
        public List<Travel> Travels { get; set; }

        //Konstruktor
        //när en instans av USER skapas så skapas en tom travelslista
        public User(string username, string password) //behövs denna?
        {
            Username = username;
            Password = password;

            //Travels = new List<Travel>();
        }

        //denna metoden sätter usernaame?
        public void IUser(string username, string password, Country location) //lägga till list?
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }

}
