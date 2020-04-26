using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class UserRole
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
