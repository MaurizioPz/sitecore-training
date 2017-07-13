using events.tac.local.Models;
using Sitecore.Globalization;
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
    public class OverviewController : Controller
    {
        // GET: Overview
        public ActionResult Index()
        {
            return View(GetModel());
        }

        private OverviewList GetModel()
        {
            var children = RenderingContext.Current.ContextItem.GetChildren(Sitecore.Collections.ChildListOptions.SkipSorting)
                .OrderBy(i=>i.Created)
                .Select(i => new OverviewItem
                {
                    URL = LinkManager.GetItemUrl(i),
                    Title = new HtmlString(FieldRenderer.Render(i, "ContentHeading")),
                    Image = new HtmlString(FieldRenderer.Render(i, "DecorationBanner", "mw=500&mh=333")),
                });
            var model = new OverviewList
            {
                ReadMore = Translate.Text("Read More"),
            };
            model.AddRange(children);
            return model;
        }
    }
}