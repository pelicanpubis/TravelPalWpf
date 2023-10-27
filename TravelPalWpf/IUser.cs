namespace TravelPalWpf
{
    public interface IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        Country Location { get; set; }


        //skriv en tom metod som andra klasser kan använda för att sätta värden //ska det vara en metod eller construcor


        //metod som andra subklasser ska använda som använder sig utav interface properties
        //ska den vara void? Eller iuser
        void IUser(string username, string password, Country location);  //ändra till setuser? makes more sense?

        //public void IUser(string username, string password, Country location)
        //{

        //}



    }


}
