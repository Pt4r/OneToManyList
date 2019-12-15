using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneToManyList.Models
{
    public class ContactPerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Company")]
        public Guid? CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}