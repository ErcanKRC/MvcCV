using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Contact> repository = new GenericRepository<Contact>();
        // GET: Contact
        public ActionResult Index()
        {
            var contact = repository.List();
            return View(contact);
        }
    }
}