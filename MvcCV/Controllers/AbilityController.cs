using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class AbilityController : Controller
    {
        AbilityRepository repository = new AbilityRepository();
        // GET: Skill
        public ActionResult Index()
        {
            var yetenekler = repository.List();

            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult AddAbility()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbility(Abilities newability)
        {
            repository.Add(newability);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbility(int id)
        {
            var ability = repository.Find(x => x.Id == id);
            repository.Delete(ability);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAbility(int id)
        {
            var ability = repository.Find(x => x.Id == id);

            return View(ability);
        }
        [HttpPost]
        public ActionResult UpdateAbility(Abilities abilityToUpddate)
        {
            var ability = repository.Find(x => x.Id == abilityToUpddate.Id);

            ability.Ability = abilityToUpddate.Ability;
            ability.Ratio = abilityToUpddate.Ratio;

            repository.Update(ability);

            return RedirectToAction("Index");
        }
    }
}