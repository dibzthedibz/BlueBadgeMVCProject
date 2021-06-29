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

        public BookService CreateBookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new BookService(userId);
            return service;
        }
    }
}