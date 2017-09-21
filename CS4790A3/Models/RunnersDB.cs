namespace CS4790A3.Models
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;

    public partial class RunnersDB : DbContext
    {
        public RunnersDB()
            : base("name=RunnersDB")
        {
        }

        public virtual DbSet<contact> contacts { get; set; }
        public virtual DbSet<runner> Runners { get; set; }

        
    }


    [Table("contact")]
    public class contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contact()
        {
            Runners = new HashSet<runner>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string suffix { get; set; }

        [Required]
        [StringLength(10)]
        public string phone { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<runner> Runners { get; set; }
    }

    [Table("Runner")]
    public class runner
    {
        public int Id { get; set; }

        public int contactID { get; set; }

        [Column("First Name")]
        [Required]
        [StringLength(50)]
        public string First_Name { get; set; }

        [Column("Last Name")]
        [Required]
        [StringLength(50)]
        public string Last_Name { get; set; }

        [Column("T-shirt")]
        [StringLength(3)]
        public string T_shirt { get; set; }

        public virtual contact contact { get; set; }
    }
}
