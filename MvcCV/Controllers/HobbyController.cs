using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HobbyController : Controller
    {
        HobbyRepository repository = new HobbyRepository();
        // GET: Hobby
        public ActionResult Index()
        {
            var hobbies = repository.List();
            return View(hobbies);
        }
        [HttpGet]
        public ActionResult AddHobby()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddHobby(Hobbies newHobby)
        {
            repository.Add(newHobby);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHobby(int id)
        {
            var hobby = repository.Find(x=> x.Id == id);
            repository.Delete(hobby);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHobby(int id)
        {
            var hobby = repository.Find(x => x.Id == id);
            return View(hobby);
        }
        [HttpPost]
        public ActionResult EditHobby(Hobbies updatedhobby)
        {
            var hobbyToUpdate = repository.Find(x=> x.Id == updatedhobby.Id);

            hobbyToUpdate.Description1 = updatedhobby.Description1;
            hobbyToUpdate.Description2 = updatedhobby.Description2;

            repository.Update(hobbyToUpdate);
            return RedirectToAction("Index");
        }
    }
}