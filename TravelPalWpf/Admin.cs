using System.Collections.Generic;

namespace TravelPalWpf
{

    //en klass som ärver interface från IUSER
    public class Admin : IUser
    {
        //properties som beskriver en Admin
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }
        public List<Travel> Travels { get; set; }



        // Country Location { get; set; }


        public Admin()
        {

        }


        //konstruktor som instierar admins properties
        public Admin(string username, string password, Country location) //konstruktor behlvs både metoden
        {
            Username = username;
            Password = password;
            Location = location;

        }

        //skriv en metod som ska förmodlingen retunera username, passord och location?
        public void IUser(string username, string password, Country location) //behövs denna?
        {
            Username = username;
            Password = password;
            Location = location;
        }
    }
}
