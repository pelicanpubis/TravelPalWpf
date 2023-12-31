﻿namespace TravelPalWpf
{
    public class WorkTrip : Travel
    {
        public string MeetingDetails { get; set; }


        public WorkTrip(string destination, Country country, int travellers, string meetingDetails, KindOfTrip kindOfTrip)
            : base(destination, country, travellers, kindOfTrip, meetingDetails)
        {
            MeetingDetails = meetingDetails;
        }




        //metod som ska returnera en sträng om work trip
        public override string GetInfo()
        {
            return $"{Country}";
        }
    }
}
