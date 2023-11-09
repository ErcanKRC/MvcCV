using MvcCV.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();

        // GET: Default
        public ActionResult Index()
        {  
            var about = db.About.ToList();
            return View(about);
        }
        public PartialViewResult Experiences()
        {
            var experience = db.Experiences.ToList();
            return PartialView(experience);
        }
        public PartialViewResult SocialMedia()
        {
            var socialMedias = db.SocialMedia.Where(x=>x.State == true).ToList();
            return PartialView(socialMedias);
        }
        public PartialViewResult Educations()
        {
            var educations = db.Educations.ToList();
            return PartialView(educations);

        }
        public PartialViewResult Abilities()
        {
            var ablities = db.Abilities.ToList();
            return PartialView(ablities);

        }
        public PartialViewResult Hobbies()
        {
            var hobbies = db.Hobbies.ToList();
            return PartialView(hobbies);

        }

        public PartialViewResult Certificates()
        {
            var certificates = db.Certificates.ToList();
            return PartialView(certificates);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Contact(Contact contact)
        {
            contact.Date = DateTime.Now;
            db.Contact.Add(contact);
            db.SaveChanges();

            return PartialView();
        }
    }
}