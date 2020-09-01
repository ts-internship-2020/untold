using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class Attendee
    {
        public int ConferenceId { get; set; }
        public string AttendeeEmail { get; set; }
        public int StatusId { get; set; }
        public string EmailCode { get; set; }

        public virtual Conference Conference { get; set; }
        public virtual DictionaryStatus Status { get; set; }
    }
}
