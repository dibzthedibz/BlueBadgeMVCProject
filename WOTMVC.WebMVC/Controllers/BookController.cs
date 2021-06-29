using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WOTMVC.Models.BookMods;
using WOTMVC.Services;

namespace WOTMVC.WebMVC.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            var service = CreateBookService();
            var model = service.GetBooks();
            return View(model);
        }

        // Get: Book/Create
        public ActionResult Create()
        {
            return View();
        }
        // Post: Book/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookCreate model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };

            var service = CreateBookService();

            if (service.CreateBook(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateBookService();
            var model = svc.GetBookById(id);

            return View(model);
        }
        public BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }
        //Get: Book/Edit
        public ActionResult Edit(int id)
        {
            var service = CreateBookService();
            var detail = service.GetBookById(id);
            var model = new BookEdit
            {
                BookId = detail.BookId,
                Title = detail.Title,
                PageCount = detail.PageCount
            };
            return View(model);
        }
        //Post: Book/Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookEdit book)
        {
            if (!ModelState.IsValid) 
                return View(book);

            //if (book.BookId != id)
            //{
            //    ModelState.AddModelError("", "Id Mismatch");
            //    return View(book);
            //}

            var service = CreateBookService();
            if (service.UpdateBook(book))
            {
                //TempData["SaveResult"] = "Book Successfully Updated.";
                return RedirectToAction("Index");
            }

            return View(book);
        }
    }
}