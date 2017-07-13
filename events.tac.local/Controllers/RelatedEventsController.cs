using events.tac.local.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class RelatedEventsController : Controller
    {
        // GET: RelatedEvents
        public ActionResult Index()
        {
            var model = GetModel();
            if (model.Any())
                return View(model);

            return new EmptyResult();
        }

        private IEnumerable<NavigationItem> GetModel()
        {
            var item = RenderingContext.Current.Rendering.Item;
            if (item == null)
                return new List<NavigationItem>();
            MultilistField relatedEvents = item.Fields["Related Events"];
            if (relatedEvents == null)
                return new List<NavigationItem>();

            return relatedEvents.GetItems()
                .Select(i => new NavigationItem
                {
                    Title = i.DisplayName,
                    URL = LinkManager.GetItemUrl(i)
                });
        }
    }
}