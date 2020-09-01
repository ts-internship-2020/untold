using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class VwLocationIds
    {
        public int LocationId { get; set; }
        public int DictionaryCountryId { get; set; }
        public int DictionaryCountyId { get; set; }
        public int DictionaryCityId { get; set; }
    }
}
