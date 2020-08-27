using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ConferenceModel
    {
        public long RowNum { get; set; }
        public String StatusId { get; set; }
        public int ConferenceId { get; set; }
        public string ConferenceName { get; set; }
        public string ConferenceCategoryName { get; set; }
        public string ConferenceTypeName { get; set; }
        public string Location { get; set; }
        public string Speaker { get; set; }
        public string Period { get; set; }
    }

    


}
