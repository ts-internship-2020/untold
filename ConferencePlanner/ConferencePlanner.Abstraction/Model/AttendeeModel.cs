using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class AttendeeModel
    {
        //public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceTypeName { get; set; }
        public string ConferenceCategoryName { get; set; }
        public string CountryName { get; set; }
        public string CountyName { get; set; }
        public string CityName { get; set; }
        public string SpeakerFirstName { get; set; }
        public string SpeakerLastName { get; set; }



    }
}
