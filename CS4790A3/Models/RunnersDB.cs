namespace CS4790A3.Models
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public class RunnersDB
    {
        public static List<Contacts> getAllContacts()
        {
            RunnersDBContext db = new RunnersDBContext();
            return db.Contacts.ToList();
        }

        public static List<Runners> getAllRunners()
        {
            RunnersDBContext db = new RunnersDBContext();
            return db.Runners.ToList();
        }

        public static ViewModel getView(int? id)
        {
            RunnersDBContext db = new RunnersDBContext();
            var vm = new ViewModel();
            vm.Contact = db.Contacts.Find(id);
            vm.Runners = db.Runners.Where(s => s.contactID.Equals(vm.Contact.Id)).ToList();
            return vm;
        }

        public static void addContact(Contacts contact)
        {
            RunnersDBContext db = new RunnersDBContext();
            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public static void addRunner(Runners runner)
        {
            RunnersDBContext db = new RunnersDBContext();
            db.Runners.Add(runner);
            db.SaveChanges();
        }

        public static void dispose()
        {
            RunnersDBContext db = new RunnersDBContext();
            db.Dispose();
        }

    }


    public class RunnersDBContext : DbContext
    {
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Runners> Runners { get; set; }
    }
    
    [Table("contact")]
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Display(Name = "suffix")]
        [StringLength(50)]
        public string suffix { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [StringLength(10)]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Column("T-shirt")]
        [StringLength(3)]
        public string T_shirt { get; set; }

        [Column("e-contact")]
        [Required]
        [StringLength(50)]
        public string e_contact { get; set; }

        [Column("e-phone")]
        [Required]
        [StringLength(10)]
        public string e_phone { get; set; }

    }

    [Table("Runners")]
    public class Runners
    {
        [Key]
        public int Id { get; set; }

        public int contactID { get; set; }

        [Display(Name="First Name")]
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50)]
        public string lastName { get; set; }
        
        [StringLength(3)]
        public string tShirt { get; set; }

    }

    public class ViewModel
    {
        public Contacts Contact { get; set; }
        public List<Runners> Runners { get; set; }
    }
}
