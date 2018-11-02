using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class CompanyContact
    {
        public int id { get; set; }
        public int compID { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public string site { get; set; }

        public Company Company { get; set; }
    }
}
