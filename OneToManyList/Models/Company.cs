using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneToManyList.Models
{
    public class Company
    {
        public Guid Id { get; set; }
        [Display(Name = "Company")]
        public string Title { get; set; }

        [Display(Name = "Contact Persons")]
        public virtual ICollection<ContactPerson> ContactPersons { get; set; }

        public Company()
        {
            ContactPersons = new HashSet<ContactPerson>();
        }
    }
}