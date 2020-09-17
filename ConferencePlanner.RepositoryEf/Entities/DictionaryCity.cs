using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class DictionaryCity
    {
        public DictionaryCity()
        {
            Location = new HashSet<Location>();
        }

        public int DictionaryCityId { get; set; }
        public string CityName { get; set; }
        public int CountyId { get; set; }

        public virtual DictionaryCounty County { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
