using System;
using System.Collections.Generic;

namespace LoginAPI.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public long RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<User> User { get; set; }
    }
}
