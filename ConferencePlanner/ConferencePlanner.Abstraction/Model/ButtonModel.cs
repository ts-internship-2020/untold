using System;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Abstraction.Model
{
    public class ButtonModel
    {
        public string email { get; set; }
        public string barcode { get; set; }
        public int confId { get; set; }
        public int statusId { get; set; }
    }
}
