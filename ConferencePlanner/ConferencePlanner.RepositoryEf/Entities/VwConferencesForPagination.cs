using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class VwConferencesForPagination
    {
        public long? RowNum { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceCategoryName { get; set; }
        public string ConferenceTypeName { get; set; }
        public string SpeakerName { get; set; }
        public string ConferencePeriod { get; set; }
        public string ConferenceName { get; set; }
        public string LocationName { get; set; }
        public string EmailOrganizer { get; set; }
    }
}
