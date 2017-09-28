using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CS4790A3.Models
{
    public class repo
    {
        public static List<Contacts> getAllContacts()
        {
            return RunnersDB.getAllContacts();
        }

        public static List<Runners> getAllRunners()
        {
            return RunnersDB.getAllRunners();
        }

        public static RegModel getRegView()
        {
            RegModel vm = new RegModel();
            vm.Contact = new Contacts();
            vm.Contact.Id = RunnersDB.getLastContactId();
            vm.Contact.FirstName = "Tim";
            vm.Contact.LastName = "Kelly";
            vm.Contact.phone = "801-719-4380";
            vm.Contact.email = "T@K.com";
            vm.confirmEmail = "T@K.com";
            var tenRunners = new List<Runners>();
            for (int dex = 0; dex < 10; dex++)
            {
                var runner = new Runners();
                runner.contactID = vm.Contact.Id;
                tenRunners.Add(runner);
            }
            vm.Runners = tenRunners;
            return vm;
        }

        public static ViewModel getView(int? id)
        {
            ViewModel vm = new ViewModel();
            vm.Contact = RunnersDB.getContact(id);
            vm.Runners = RunnersDB.getRunners(id);
            return vm;
        }

        public static void addContact(Contacts contact)
        {
            RunnersDB.addContact(contact);
        }

        public static void addRunner(Runners runner)
        {
            RunnersDB.addRunner(runner);
        }
    }
}