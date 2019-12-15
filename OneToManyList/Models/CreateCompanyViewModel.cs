using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneToManyList.Models
{
    public class CreateCompanyViewModel
    {
        public Company Company { get; set; }
        public IEnumerable<ContactPerson> ContactPersons { get; set; }
    }
}