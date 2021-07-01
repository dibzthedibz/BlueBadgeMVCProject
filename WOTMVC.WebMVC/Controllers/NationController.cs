//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WOTMVC.Models.NationMods;
//using WOTMVC.Services;

//namespace WOTMVC.WebMVC.Controllers
//{
//    public class NationController : Controller
//    {
//        // GET: Nation
//        public ActionResult Index()
//        {
//            var service = CreateNationService();
//            var model = service.GetNations();
//            return View(model);
//        }

//        // Get: Nation/Create
//        public ActionResult Create()
//        {
//            return View();
//        }
//        //// Post: Nation/Create
//        [HttpPost, ActionName("Create")]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(NationCreate model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            };
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new NationService(userId);

//            if (service.CreateNation(model))
//            {
//                return RedirectToAction("Index");
//            }
//            return View(model);
//        }

//        public NationService CreateNationService()
//        {
//            var userId = Guid.Parse(User.Identity.GetUserId());
//            var service = new NationService(userId);
//            return service;
//        }
//        Get: Nation/Details/{id
//        public ActionResult Details(int id)
//        {
//            var svc = CreateNationService();
//            var model = svc.GetNationById(id);

//            return View(model);
//        }

//        //Get: Nation/Edit
//        public ActionResult Edit(int id)
//        {
//            var service = CreateNationService();
//            var detail = service.GetNationById(id);
//            var model = new NationEdit
//            {
//                NationId = detail.NationId,
//                NationName = detail.NationName,
//                Terrain = detail.Terrain,
//                Trades = detail.Trades
//            };
//            return View(model);
//        }
//        //Post: Nation/Edit
//        [HttpPost, ActionName("Edit")]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(int id, NationEdit nation)
//        {
//            if (!ModelState.IsValid)
//                return View(nation);

//            //if (nation.NationId != id)
//            //{
//            //    ModelState.AddModelError("", "Id Mismatch");
//            //    return View(nation);
//            //}

//            var service = CreateNationService();
//            if (service.UpdateNation(nation))
//            {
//                //TempData["SaveResult"] = "Nation Successfully Updated.";
//                return RedirectToAction("Index");
//            }

//            return View(nation);
//        }
//        //Get: Nation/Delete
//        public ActionResult Delete(int id)
//        {
//            var svc = CreateNationService();
//            var model = svc.GetNationById(id);

//            return View(model);
//        }
//        //Post: Product/Delete/{id}
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteChap(int id)
//        {
//            var service = CreateNationService();

//            service.DeleteNation(id);

//            //TempData["SaveResult"] = "Nation Successfully Deleted";

//            return RedirectToAction("Index");
//        }
//    }
//}