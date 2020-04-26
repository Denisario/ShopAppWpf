using System;
using System.Collections.Generic;
using System.Text;

namespace PartShop.Domain.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Account Account { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
