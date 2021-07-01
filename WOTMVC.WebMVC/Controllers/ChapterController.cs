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
            //var chapters = service.CreateChapterList();
            //var service1 = CreateCharacterService();
            //var chars = service1.CreateCharacterList();
            //ViewBag.CharacterId = new SelectList(chars, "CharacterId", "FirstName");
            //ViewBag.ChapterId = new SelectList(chapters, "ChapterId", "Title");
            var service2 = CreateBookService();
            var books = service2.GetBooks();
            ViewBag.BookId = new SelectList(books, "BookId", "Title");
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
        public ActionResult Details(int id)
        {
            var svc = CreateChapterService();
            var model = svc.GetChapterById(id);

            return View(model);
        }
        
        //Get: Chapter/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateChapterService();
            var detail = service.GetChapterById(id);
            var model = new ChapterEdit
            {
                ChapterId = detail.ChapterId,
                ChapTitle = detail.ChapTitle,
                PageCount = detail.PageCount
            };
            return View(model);
        }
        //Post: Chapter/Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ChapterEdit chapter)
        {
            if (!ModelState.IsValid)
                return View(chapter);

            //if (chapter.ChapterId != id)
            //{
            //    ModelState.AddModelError("", "Id Mismatch");
            //    return View(chapter);
            //}

            var service = CreateChapterService();
            if (service.UpdateChapter(chapter))
            {
                //TempData["SaveResult"] = "Chapter Successfully Updated.";
                return RedirectToAction("Index");
            }

            return View(chapter);
        }
        // Post: Chapter/AddBook
        public ActionResult AddBook(int id)
        {
            var service = CreateChapterService();
            var detail = service.GetChapterById(id);
            var model = new ChapterDetail
            {
                ChapterId = detail.ChapterId,
                ChapTitle = detail.ChapTitle,
            };
            return View(model);
        }
        //Get: Chapter/Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateChapterService();
            var model = svc.GetChapterById(id);

            return View(model);
        }
        //Post: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteChap(int id)
        {
            var service = CreateChapterService();

            service.DeleteChapter(id);

            //TempData["SaveResult"] = "Chapter Successfully Deleted";

            return RedirectToAction("Index");
        }
        public ChapterService CreateChapterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ChapterService(userId);
            return service;
        }
        public BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }
    }

    
}