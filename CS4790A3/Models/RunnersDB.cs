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

        public static int getLastContactId()
        {
            RunnersDBContext db = new RunnersDBContext();
            int maxID = db.Contacts.Select(p => p.Id).DefaultIfEmpty(1).Max();
            return maxID;
        }

        public static List<Runners> getAllRunners()
        {
            RunnersDBContext db = new RunnersDBContext();
            return db.Runners.ToList();
        }

        public static Contacts getContact(int? id)
        {
            RunnersDBContext db = new RunnersDBContext();
            return db.Contacts.Find(id); 
        }

        public static List<Runners> getRunners(int? id)
        {
            RunnersDBContext db = new RunnersDBContext();
            return db.Runners.Where(s => s.contactID.Equals(id)).ToList();
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
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Please enter a valid Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Please enter a valid Name.")]
        public string LastName { get; set; }

        [Display(Name = "Suffix")]
        [StringLength(50)]
        public string suffix { get; set; }

        [Display(Name = "Anonymus")]
        public Boolean anonymous { get; set; }

        [Display(Name = "Phone")]
        [Required]
        [StringLength(13, MinimumLength = 12)]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid Phone #.")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid Email.")]
        public string email { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("email", ErrorMessage = "The Email and confirmation Email do not match.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Please enter a valid Email.")]
        public string emailConfirm { get; set; }

        [Display(Name = "T-shirt Size")]
        [Column("T-shirt")]
        [StringLength(3, MinimumLength = 1)]
        public string T_shirt { get; set; }

        [Display(Name = "Emergincy Contact")]
        [Column("e-contact")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Please enter a valid Name.")]
        public string e_contact { get; set; }

        [Display(Name = "Emergincy Phone")]
        [Column("e-phone")]
        [Required]
        [StringLength(13, MinimumLength = 12)]
        [RegularExpression(@"^[2-9]\d{2}-\d{3}-\d{4}$", ErrorMessage = "Please enter a valid Phone #.")]
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
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Please enter a valid Name.")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z])?[a-zA-Z]*)*$", ErrorMessage = "Please enter a valid Name.")]
        public string lastName { get; set; }
        
        [StringLength(3)]
        public string tShirt { get; set; }

    }

    public class ViewModel
    {
        public Contacts Contact { get; set; }
        public Runners RunnersModel { get; set; }
        public List<Runners> Runners { get; set; }
    }
}
