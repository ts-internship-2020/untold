using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryStatus
    {
        public DictionaryStatus()
        {
            Attendee = new HashSet<Attendee>();
        }

        public int DictionaryStatusId { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Attendee> Attendee { get; set; }
    }
}
