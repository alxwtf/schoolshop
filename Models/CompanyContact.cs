using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class CompanyContact
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Site { get; set; }

        public Company Company { get; set; }
    }
}
