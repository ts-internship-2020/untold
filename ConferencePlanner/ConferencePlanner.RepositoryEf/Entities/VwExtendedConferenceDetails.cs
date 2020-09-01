using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class VwExtendedConferenceDetails
    {
        public int ConferenceId { get; set; }
        public string ConferenceCategoryName { get; set; }
        public string ConferenceTypeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceName { get; set; }
        public string CountryName { get; set; }
        public string CountyName { get; set; }
        public string CityName { get; set; }
        public string EmailOrganizer { get; set; }
    }
}
