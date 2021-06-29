using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WOTMVC.Models.NationMods;
using WOTMVC.Services;

namespace WOTMVC.WebMVC.Controllers
{
    public class NationController : Controller
    {
        // GET: Nation
        public ActionResult Index()
        {
            var service = CreateNationService();
            var model = service.GetNations();
            return View(model);
        }

        // Get: Nation/Create
        public ActionResult Create()
        {
            return View();
        }
        // Post: Nation/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(NationCreate model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NationService(userId);

            if (service.CreateNation(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public NationService CreateNationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NationService(userId);
            return service;
        }
    }
}