using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repository = new ExperienceRepository();

        // GET: Experience
        public ActionResult Index()
        {
            var values = repository.List();


            return View(values);
        }
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(Experiences experience)
        {
            repository.Add(experience);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            Experiences experience = repository.Find(x => x.Id == id);
            repository.Delete(experience);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Experiences experience = repository.Find(x => x.Id == id);
            return View(experience);
        }
        [HttpPost]
        public ActionResult UpdateExperience(Experiences exptoUpdate)
        {
            Experiences experience = repository.Find(x => x.Id == exptoUpdate.Id);

            experience.Title = exptoUpdate.Title;
            experience.Description = exptoUpdate.Description;
            experience.Date = exptoUpdate.Date;
            experience.Company = exptoUpdate.Company;

            repository.Update(experience);

            return RedirectToAction("Index");
        }
    }
}