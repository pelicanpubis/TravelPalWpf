namespace TravelPalWpf
{

    //en klass som ärver interface från IUSER
    public class Admin : IUser
    {
        //properties som beskriver en Admin
        public string Username { get; set; }
        public string Password { get; set; }
        public Country Location { get; set; }


        //konstruktor som instierar admins properties
        public Admin(string username, string password, Country location) //konstruktor behlvs både metoden
        {
            Username = username;
            Password = password;
            Location = location;
            // MeetingDetails = meetingDetails;
        }
    }
}
