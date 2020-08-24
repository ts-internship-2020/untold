using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceModel
    {
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public string ConferenceCategoryName { get; set; }
        public string ConferenceTypeName { get; set; }
        public string LocationName { get; set; }
        public string SpeakerName { get; set; }
        public string Period { get; set; }
    }

    


}
