using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class ImportCities
    {
        public double? DictionaryCityId { get; set; }
        public string CityName { get; set; }
        public double? CountyId { get; set; }
    }
}
