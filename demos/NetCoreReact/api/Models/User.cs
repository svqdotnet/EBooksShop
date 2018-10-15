using System;
using System.Collections.Generic;

namespace LoginAPI.Models
{
    public partial class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public long RoleId { get; set; }
        public byte[] Salt { get; set; }
        public byte[] Password { get; set; }

        public Role Role { get; set; }
    }
}
