using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechieTree.Models
{
    public class Event
    {
        public int Eventid { get; set; }
        public string subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }
    }
}