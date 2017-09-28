using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using CS4790A3.Models;

namespace CS4790A3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(repo.getRegView());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegModel registration)
        {
            if (ModelState.IsValid)
            {
                repo.addContact(registration.Contact);
                addRunners(registration.Runners);
                return RedirectToAction("Registrants");
            }

            return View();

        }

        public void addRunners(List<Runners> runners)
        {
            foreach(var runner in runners)
            {
                if (runner.firstName != null && runner.lastName != null)
                {
                    repo.addRunner(runner);
                }
            }
        }

        // GET: Home/Registrants
        public ActionResult Registrants()
        {
            return View(repo.getAllContacts());
        }

        // GET: Contacts/Details/5
        public ActionResult Registrant(int? id)
        {
            return View(repo.getView(id));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrant(Runners runner)
        {
            if (ModelState.IsValid)
            {
                repo.addRunner(runner);
                return View(repo.getView(runner.contactID));
            }

            return View("Index");

        }




    }
}