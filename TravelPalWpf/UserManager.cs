﻿namespace TravelPalWpf
{
    using System.Collections.Generic;

    public static class UserManager
    {

        public static List<IUser> Users { get; private set; } = new()
        {
            //vi kallar på en tom konstruktor så att vi kan bygga vår egna user
            
            new Admin("admin", "password", Country.France),
            new User("user", "password", Country.Sweden)
             {
                Travels = new List<Travel>()
                {
                new WorkTrip ()
                {
                    Destination = "Kabul",
                    Country = Country.Afghanistan,
                    Travellers = 1,
                    KindOfTrip = KindOfTrip.WorkTrip,
                    MeetingDetails = "sa,sd",
                },
                new Vacation()
                {
                    Destination="Kosovo",
                    Country = Country.Albania,
                    Travellers = 1,
                    KindOfTrip= KindOfTrip.Vacation,
                    AllInclusive = true,

                }

                }

            }

        };

        public static IUser? SignedInUser { get; private set; }

        //denna metoden registrerar en ny user
        public static User? RegisterUser(string username, string password, Country country)
        {

            //kontrollerar om det nya användar namnet är ''valid''
            if (ValidateUsername(username))
            {
                //om det är valid så skapas en ny user objekt och initialiserar dens properties
                User newUser = new User(username, password, country)
                {
                    Travels = new List<Travel>()
                };
                //lägger till den nya user i users listan
                Users.Add(newUser);

                return newUser;
            }

            return null;



        }


        //lägger till user i user listan,
        public static bool AddUser(IUser user)
        {
            //lägg till logik

            return false;
        }

        //metod som ska ta bort från user from listan.
        public static void RemoveUser(IUser user)
        {
            //{
            //    Users.Remove(user);
            //}
        }




        //uppdatera användernamn om det nya användarnamnet är true?
        public static bool UpdateUsername(IUser user, string newUsername)
        {
            //logik
            return true;
        }


        //Metod: Kollar om användar namn inte är taget
        public static bool ValidateUsername(string username)
        {
            bool isValidUsername = true;

            //loopar genom users listan för att se om användarnamnet är taget
            foreach (var user in Users)
            {
                if (user.Username == username)
                {

                    //om namnet är redan taget så kommer valid namn är retunera false
                    isValidUsername = false;
                }
            }
            //annars sant
            return isValidUsername;
        }

        //metod som loggar in användaren
        public static bool SignInUser(string username, string password)
        {
            foreach (var user in Users)
            {
                if (user.Username == username && user.Password == password)
                {
                    // User found!

                    SignedInUser = user;

                    return true;
                }
            }

            return false;
        }

        public static void SignOutUser() //kallas på sign out knappen
        {
            SignedInUser = null;
        }

        public static List<Travel> GetAllUsersTravels()
        {
            // Skapar en lista för att samla alla users resor
            List<Travel> allTravels = new List<Travel>();


            // Loopa igenom varje användare i Users listan
            foreach (var user in Users)
            {

                if (user is User userAsUser)
                {
                    {
                        // Lägg till alla resor från användaren i listan allTravels
                        allTravels.AddRange(userAsUser.Travels);
                    }
                }
            }

            return allTravels;
        }





    }

}
