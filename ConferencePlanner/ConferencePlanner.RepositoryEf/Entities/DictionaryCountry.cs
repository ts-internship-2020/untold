using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryCountry
    {
        public DictionaryCountry()
        {
            DictionaryCounty = new HashSet<DictionaryCounty>();
        }

        public int DictionaryCountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        public virtual ICollection<DictionaryCounty> DictionaryCounty { get; set; }
    }
}
