using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WOTMVC.Models.CharacterMods;
using WOTMVC.Services;

namespace WOTMVC.WebMVC.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        // GET: Character
        public ActionResult Index()
        {
            var service = CreateCharacterService();
            var model = service.GetCharacters();
            return View(model);
        }

        // Get: Character/Create
        public ActionResult Create()
        {
            var service1 = CreateNationService();
            var nations = service1.GetNations();
            ViewBag.NationId = new SelectList(nations, "NationId", "NationName");

            return View();
        }

        // Post: Character/Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CharacterCreate model)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };
           
            var service = CreateCharacterService();

            if (service.CreateCharacter(model))
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }

        //Get: Character/Edit
        public ActionResult Edit(int id)
        {
            var service1 = CreateNationService();
            var nations = service1.GetNations();
            ViewBag.NationId = new SelectList(nations, "NationId", "NationName");

            var service = CreateCharacterService();
            var detail = service.GetCharacterById(id);
            var model = new CharacterEdit
            {
                CharacterId = detail.CharacterId,
                FirstName = detail.FirstName,
                LastName = detail.LastName,
                Ability = detail.Ability,
                Image = detail.Image,
                NationId = detail.NationId
                //Birthplace = detail.Birthplace
            };
            return View(model);
        }
        //Post: Character/Edit
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CharacterEdit character)
        {
            if (!ModelState.IsValid)
                return View(character);

            //if (character.CharacterId != id)
            //{
            //    ModelState.AddModelError("", "Id Mismatch");
            //    return View(character);
            //}

            var service = CreateCharacterService();
            if (service.UpdateCharacter(character))
            {
                //TempData["SaveResult"] = "Character Successfully Updated.";
                return RedirectToAction("Index");
            }

            return View(character);
        }
        //Get: Character/Delete
        public ActionResult Delete(int id)
        {
            var svc = CreateCharacterService();
            var model = svc.GetCharacterById(id);

            return View(model);
        }
        //Post: Product/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteChap(int id)
        {
            var service = CreateCharacterService();

            service.DeleteCharacter(id);

            //TempData["SaveResult"] = "Character Successfully Deleted";

            return RedirectToAction("Index");
        }

        public CharacterService CreateCharacterService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CharacterService(userId);
            return service;
        }

        public NationService CreateNationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new NationService(userId);
            return service;
        }
    }
}