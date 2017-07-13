using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAC.Utils.Mvc;

namespace events.tac.local.Controllers
{
    public class SubscribeFormController : Controller
    {
        // GET: SubscribeForm
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateFormHandler]
        public ActionResult Index(string email)
        {
            return View("Confirmation");
        }
    }
}