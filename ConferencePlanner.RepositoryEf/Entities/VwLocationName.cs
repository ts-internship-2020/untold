using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class VwLocationName
    {
        public int LocationId { get; set; }
        public string CountryName { get; set; }
        public string CountyName { get; set; }
        public string CityName { get; set; }
    }
}
