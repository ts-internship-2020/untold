using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryConferenceType
    {
        public DictionaryConferenceType()
        {
            Conference = new HashSet<Conference>();
        }

        public int DictionaryConferenceTypeId { get; set; }
        public string ConferenceTypeName { get; set; }

        public virtual ICollection<Conference> Conference { get; set; }
    }
}
