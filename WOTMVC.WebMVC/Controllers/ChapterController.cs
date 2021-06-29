using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WOTMVC.Models.ChapterMods;
using WOTMVC.Services;

namespace WOTMVC.WebMVC.Controllers
{
    public class ChapterController : Controller
    {
        // GET: Chapter
        public ActionResult Index()
        {
            var service = CreateChapterService();
            var model = service.GetChaps();
            return View(model);
        }
        public ActionResult Create()
        {
            //var service = CreateChapterService();
            //var books = service.CreateBookList();
            //var service1 = CreateCharacterService();
            //var chars = service1.CreateCharacterList();
            //ViewBag.CharacterId = new SelectList(chars, "CharacterId", "FirstName");
            //ViewBag.BookId = new SelectList(books, "BookId", "Title");
            return View();
        }
        // Post: Chapter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChapterCreate model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var service = CreateChapterService();
            if (service.ChapterCreate(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ChapterService CreateChapterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChapterService(userId);
            return service;
        }
    }
}