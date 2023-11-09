using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SocialMediaController : Controller
    {
        SocialMediaRepository repository = new SocialMediaRepository();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var socialMedias = repository.List();

            return View(socialMedias);
        }

        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(SocialMedia newSocialMedia)
        {
            repository.Add(newSocialMedia);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var socialMedia = repository.Find(x => x.Id == id);

            socialMedia.State = false;

            repository.Update(socialMedia);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var socialMedia = repository.Find(x => x.Id == id);
            return View(socialMedia);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMediaToUpdate)
        {
            var socialMedia = repository.Find(x => x.Id == socialMediaToUpdate.Id);

            socialMedia.Name = socialMediaToUpdate.Name;
            socialMedia.Url = socialMediaToUpdate.Url;
            socialMedia.Icon = socialMediaToUpdate.Icon;
            socialMedia.State = true;

            repository.Update(socialMedia);

            return RedirectToAction("Index");
        }
    }
}