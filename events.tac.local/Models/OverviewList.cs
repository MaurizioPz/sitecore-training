using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class OverviewList : List<OverviewItem>
    {
        public string ReadMore { get; set; }
    }
}