using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCsite.Models.Entities
{
    public class Tag
    {
        public Tag()
        {
            Sites = new HashSet<Site>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
    }
}