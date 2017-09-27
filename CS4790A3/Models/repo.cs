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

        public static ViewModel getRegView()
        {
            ViewModel vm = new ViewModel();
            vm.Contact = new Contacts();
            vm.RunnersModel = new Runners();
            vm.RunnersModel.contactID = RunnersDB.getLastContactId();
            return vm;
        }

        public static ViewModel getView(int? id)
        {
            
            ViewModel vm = new ViewModel();
            vm.Contact = RunnersDB.getContact(id);
            Runners Runner = new Runners();
            Runner.contactID = vm.Contact.Id;
            vm.RunnersModel = Runner;
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