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
            return View(repo.getAllRunners());
        }



        // GET: Home/Registrants
        public ActionResult Registrants()
        {
            return View(repo.getAllContacts());
        }

        // GET: Home/Regeter
        public ActionResult Register()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "Id,FirstName,LastName,suffix,phone,email,T_shirt,e_contact,e_phone")] Contacts contact)
        {
            if (ModelState.IsValid)
            {
                repo.addContact(contact);
                return RedirectToAction("Registrant", new { id = contact.Id });
            }

            return View(contact);
        }

        // GET: Contacts/Details/5
        public ActionResult Registrant(int? id)
        {
            return View(repo.getView(id));
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrant([Bind(Include = "Id,contactID,firstName,lastName,tShirt")] Runners runner)
        {
            if (ModelState.IsValid)
            {
                repo.addRunner(runner);
            }

            return View(repo.getView(runner.contactID));
        }



    }
}