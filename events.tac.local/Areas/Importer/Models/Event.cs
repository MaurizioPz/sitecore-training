using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Areas.Importer.Models
{
    public class Event
    {
        public string ContentHeading { get; set; }
        public string ContentIntro { get; set; }
        public string Highlights { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }

    }
}