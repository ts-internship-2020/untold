using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class CityModel
    {
        public int DictionaryCityId { get; set; }
        public string CityName { get; set; }

        public int CountyId { get; set; }
    }
}
