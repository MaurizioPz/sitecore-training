using events.tac.local.Models;
using Sitecore.Mvc.Presentation;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class FeaturedEventController : Controller
    {
        // GET: FeaturedEvent
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private FeaturedEvent CreateModel()
        {
            var item = RenderingContext.Current.Rendering.Item;
            return new FeaturedEvent()
            {
                Heading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "Event Image", "mw=400")),
                Intro = new HtmlString(FieldRenderer.Render(item, "ContentIntro")),
            };
        }
    }
}