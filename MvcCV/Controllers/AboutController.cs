using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository repository = new AboutRepository();
        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var about = repository.List();
            return View(about);
        }
        [HttpPost]
        public ActionResult Index(About updatedAbout)
        {
            var aboutfromdb = repository.Find(x => x.Id == updatedAbout.Id);

            aboutfromdb.Name = updatedAbout.Name;
            aboutfromdb.SurName = updatedAbout.SurName;
            aboutfromdb.Adress = updatedAbout.Adress;
            aboutfromdb.Description = updatedAbout.Description;
            aboutfromdb.Phone = updatedAbout.Phone;
            aboutfromdb.Photo = updatedAbout.Photo;

            repository.Update(aboutfromdb);
            return RedirectToAction("Index");
        }
    }
}