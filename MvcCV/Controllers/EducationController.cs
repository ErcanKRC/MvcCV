using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class EducationController : Controller
    {
        public EducationRepository repository = new EducationRepository();
        // GET: Education
        public ActionResult Index()
        {
            var eğitim = repository.List();
            return View(eğitim);
        }
        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Educations newEducation)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            repository.Add(newEducation);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        {
            var education = repository.Find(x => x.Id == id);
            repository.Delete(education);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var education = repository.Find(x => x.Id == id);

            return View(education);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Educations educationToUpdate)
        {
            var education = repository.Find(x => x.Id == educationToUpdate.Id);

            education.Title = educationToUpdate.Title;
            education.Subtitle1 = educationToUpdate.Subtitle1;
            education.Subtitle2 = educationToUpdate.Subtitle2;
            education.Date = educationToUpdate.Date;
            education.GPA = educationToUpdate.GPA;

            repository.Update(education);

            return RedirectToAction("Index");
        }
    }
}