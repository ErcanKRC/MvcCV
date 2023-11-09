using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class CertificateController : Controller
    {
        CertificateRepository repository = new CertificateRepository();
        // GET: Certificate
        public ActionResult Index()
        {
            var certificates = repository.List().OrderByDescending(x => x.Date).ToList();
            return View(certificates);
        }

        [HttpGet]
        public ActionResult AddCertificate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCertificate(Certificates newcertificate)
        {
            repository.Add(newcertificate);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCertificate(int id)
        {
            var certificate = repository.Find(x=>x.Id == id);
            repository.Delete(certificate);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCertificate(int id)
        {
            var certificate = repository.Find(x => x.Id == id);
            return View(certificate);
        }
        [HttpPost]
        public ActionResult UpdateCertificate(Certificates certificateToUpdate)
        {
            var certificate = repository.Find(x => x.Id == certificateToUpdate.Id);

            certificate.Title = certificateToUpdate.Title;
            certificate.SubTitle = certificateToUpdate.SubTitle;
            certificate.Date = certificateToUpdate.Date;
            repository.Update(certificate);

            return RedirectToAction("Index");
        }

        public ActionResult GetCertificate(int id)
        {
            return View();
        }
    }
}