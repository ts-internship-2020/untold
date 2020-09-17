using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryCounty
    {
        public DictionaryCounty()
        {
            DictionaryCity = new HashSet<DictionaryCity>();
        }

        public int DictionaryCountyId { get; set; }
        public string CountyName { get; set; }
        public int CountryId { get; set; }

        public virtual DictionaryCountry Country { get; set; }
        public virtual ICollection<DictionaryCity> DictionaryCity { get; set; }
    }
}
