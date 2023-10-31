namespace TravelPalWpf
{
    using System.Collections.Generic;

    public static class UserManager
    {

        public static List<IUser> Users { get; private set; } = new()
             {
            new User("user", "password",Country.Sweden),
            new Admin("admin", "password",Country.Afghanistan)

        };
        public static IUser? SignedInUser { get; private set; }
        // public Country Location { get; private set; } denna funkar inte?

        //konstruktor med en tom Users lista. Den sätter även signed user till null.
        //public static UserManager()
        //{
        //    Users = new List<IUser>();
        //    SignedInUser = null;
        //}

        //public void IUser(string username, string password, Country location) //från íuser men behövs den?
        //{
        //    return;
        //}

        public static User? RegisterUser(string username, string password, Country country)
        {
            if (ValidateUsername(username))
            {
                User newClient = new(username, password, country);

                Users.Add(newClient);

                return newClient;
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


        //metod som validerar användarnamn
        public static bool ValidateUsername(string username)
        {
            bool isValidUsername = true;

            foreach (var user in Users)
            {
                if (user.Username == username)
                {
                    isValidUsername = false;
                }
            }

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

        //public static void SignOutUser()
        //{
        //    SignedInUser = null;
        //}
    }

}
