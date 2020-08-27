using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class SpeakerModel
    {
        public int SpeakerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nationality { get; set; }
        public float Rating { get; set; }
        public string ImagePath { get; set; }

    }

    


}
