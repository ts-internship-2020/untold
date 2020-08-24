using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class CountryModel
    {
        public string CountryName { get; set; }
        public override string ToString()
        {
            return CountryName;
        }
    }
}
