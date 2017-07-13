using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAC.Utils.Mvc;

namespace events.tac.local.Controllers
{
    public class CommentsFormController : Controller
    {
        // GET: CommentsForm
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateFormHandler]
        public ActionResult Index(string name, string comment)
        {
            return View("Confirmation");
        }
    }
}