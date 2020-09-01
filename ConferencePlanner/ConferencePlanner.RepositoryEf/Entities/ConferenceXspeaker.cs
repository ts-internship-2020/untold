using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class ConferenceXspeaker
    {
        public int ConferenceId { get; set; }
        public int SpeakerId { get; set; }

        public virtual Conference Conference { get; set; }
        public virtual Speaker Speaker { get; set; }
    }
}
