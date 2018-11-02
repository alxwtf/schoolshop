using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Company
    {
        public int id { get; set; }
        public int Name { get; set; }
        public List<CompanyContact> CompanyContacts { get; set; }
    }
}
