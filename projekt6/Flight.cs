using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace projekt6
{
    public class Flight
    {
        public string flightNumber { get; set; }
        public string from { get; set; }
        public string destination { get; set; }
        public string status { get; set; }
        public int statusIndex {get;set;}
        public int isOut{get;set;}
    }
}
