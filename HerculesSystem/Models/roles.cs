using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HerculesSystem.Models
{
   
    public partial class roles
    {
        public roles()
        {
            this.users = new HashSet<users>();
        }

        public int RoleId { get; set; }
        public string Description { get; set; }

        public virtual ICollection<users> users { get; set; }
    }
}
