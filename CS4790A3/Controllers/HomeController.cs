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

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addContact([Bind(Include = "Id,FirstName,LastName,suffix,phone,email,T_shirt,e_contact,e_phone,emailConfirm,anonymous")] Contacts contact)
        {
            if (ModelState.IsValid)
            {
                repo.addContact(contact);
                return RedirectToAction("Registrant", new { id = contact.Id });
            }

            return RedirectToAction("index");
        }

        // POST: Runners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addRunner([Bind(Include = "Id,contactID,firstName,lastName,tShirt")] Runners runner)
        {
            if (ModelState.IsValid)
            {
                repo.addRunner(runner);
                return RedirectToAction("Registrant", new { id = runner.contactID });
            }

            return RedirectToAction("index");
            
        }



    }
}