using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Conference
    {
        public Conference()
        {
            Attendee = new HashSet<Attendee>();
            ConferenceXspeaker = new HashSet<ConferenceXspeaker>();
        }

        public int ConferenceId { get; set; }
        public int? ConferenceCategoryId { get; set; }
        public int? ConferenceTypeId { get; set; }
        public int? LocationId { get; set; }
        public int? MainSpeakerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ConferenceName { get; set; }
        public string EmailOrganizer { get; set; }

        public virtual DictionaryConferenceCategory ConferenceCategory { get; set; }
        public virtual DictionaryConferenceType ConferenceType { get; set; }
        public virtual Location Location { get; set; }
        public virtual Speaker MainSpeaker { get; set; }
        public virtual ICollection<Attendee> Attendee { get; set; }
        public virtual ICollection<ConferenceXspeaker> ConferenceXspeaker { get; set; }
    }
}
