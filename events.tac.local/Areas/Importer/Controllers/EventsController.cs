using events.tac.local.Areas.Importer.Models;
using Newtonsoft.Json;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace events.tac.local.Areas.Importer.Controllers
{
    public class EventsController : Controller
    {
        // GET: Importer/Events
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file, string parentPath)
        {
            using(var reader = new StreamReader(file.InputStream))
            {
                var events = JsonConvert.DeserializeObject<IEnumerable<Event>>(reader.ReadToEnd());
                CreateEvents(events, parentPath);
            }
            return View();
        }

        private void CreateEvents(IEnumerable<Event> events, string parentPath)
        {
            var database = Factory.GetDatabase("master");
            var parent = database.GetItem(parentPath);
            var templateId = new TemplateID(new ID("{901656E7-1376-400C-AEF2-D8B8684B9FB4}"));
            using(new SecurityDisabler())
            {
                foreach (var ev in events)
                {
                    var name = ItemUtil.ProposeValidItemName(ev.ContentHeading);
                    var item = parent.Add(name, templateId);
                    using(new EditContext(item))
                    {
                        item["ContentHeading"] = ev.ContentHeading;
                        item["ContentIntro"] = ev.ContentIntro;
                        item["Difficulty Level"] = ev.Difficulty.ToString();
                        item["Duration"] = ev.Duration.ToString();
                        item["Highlights"] = ev.Highlights;
                        item["Start Date"] = Sitecore.DateUtil.ToIsoDate(ev.StartDate);
                    }
                }
            }
        }
    }
}