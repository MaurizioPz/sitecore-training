using events.tac.local.Models;
using Sitecore;
using Sitecore.Links;
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
            var model = new FeaturedEvent()
            {
                Heading = new HtmlString(FieldRenderer.Render(item, "ContentHeading")),
                EventImage = new HtmlString(FieldRenderer.Render(item, "Event Image", "mw=400")),
                Intro = new HtmlString(FieldRenderer.Render(item, "ContentIntro")),
                URL = LinkManager.GetItemUrl(item)
            };
            var parameters = RenderingContext.Current.Rendering.Parameters;
            var cssClass = parameters["CssClass"];
            if (!string.IsNullOrEmpty(cssClass))
            {
                var refItem = Context.Database.GetItem(cssClass);
                if (refItem == null)
                    model.CssClass = cssClass;
                else
                    model.CssClass = refItem["class"];

            }
            return model;
        }
    }
}