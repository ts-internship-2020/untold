using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceModelWithEmail
    {
        public int ConferenceId { get; set; }
        public int ConferenceCategoryId { get; set; }
        public int ConferenceTypeId { get; set; }
        public int LocationId { get; set; }
        public int MainSpeakerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceName { get; set; }
        public string Email { get; set; }
        
    }

    


}
