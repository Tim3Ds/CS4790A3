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

        public static ViewModel getView(int? id)
        {
            return RunnersDB.getView(id);
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