using events.tac.local.Models;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Controllers
{
    public class EventsListController : Controller
    {
        private const int PageSize = 4;

        // GET: EventsList
        public ActionResult Index(int page = 1)
        {
            return View(CreateModel(page));
        }

        private EventsList CreateModel(int page)
        {
            var contextItem = RenderingContext.Current.ContextItem;
            var index = GetIndex(contextItem);
            using (var context = index.CreateSearchContext())
            {
                var results = context.GetQueryable<EventDetails>()
                    .Where(i => i.Paths.Contains(contextItem.ID) && i.Language == contextItem.Language.Name)
                    .Page(page - 1, PageSize)
                    .GetResults();
                return new EventsList
                {
                    Events = results.Hits.Select(h => h.Document).ToList(),
                    TotalResultCount = results.TotalSearchResults,
                    PageSize = PageSize
                };
            }
        }

        private static ISearchIndex GetIndex(Item contextItem)
        {
            var databaseName = contextItem.Database.Name.ToLower();
            var indexName = string.Format("events_{0}_index", databaseName);
            return ContentSearchManager.GetIndex(indexName);
        }
    }
}