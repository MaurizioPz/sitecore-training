using events.tac.local.Models;
using Sitecore;
using Sitecore.Links;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class BreadcrumbController : Controller
    {
        // GET: Breadcrumb
        public ActionResult Index()
        {
            return View(CreateModel());
        }

        private IEnumerable<NavigationItem> CreateModel()
        {
            var item = RenderingContext.Current.ContextItem;
            var home = Context.Database.GetItem(Context.Site.StartPath);
            var breadcrumb = item.Axes.GetAncestors()
                .Where(i => i.Axes.IsDescendantOf(home))
                .Concat(new[] { item });
            return breadcrumb.Select(b => new NavigationItem
            {
                Title = b.DisplayName,
                URL = LinkManager.GetItemUrl(b),
                Active = b.ID == item.ID
            });
        }
    }
}