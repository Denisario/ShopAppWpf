using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
