using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Speaker
    {
        public Speaker()
        {
            Conference = new HashSet<Conference>();
            ConferenceXspeaker = new HashSet<ConferenceXspeaker>();
        }

        public int SpeakerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public double? Rating { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Conference> Conference { get; set; }
        public virtual ICollection<ConferenceXspeaker> ConferenceXspeaker { get; set; }
    }
}
