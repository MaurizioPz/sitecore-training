using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace events.tac.local.Models
{
    public class FeaturedEvent
    {
        public FeaturedEvent()
        {

        }

        public HtmlString Heading { get; set; }
        public HtmlString Intro { get; set; }
        public HtmlString EventImage { get; set; }
        public string CssClass { get; internal set; }
        public string URL { get; internal set; }
    }
}