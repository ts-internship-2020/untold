using System;
using System.Collections.Generic;

namespace ConferencePlanner.Repository.Ef.Entities
{
    public partial class ImportCounty
    {
        public double? CountyId { get; set; }
        public string CountyName { get; set; }
        public double? CountryId { get; set; }
    }
}
