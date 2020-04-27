using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    public class User
    {
        //[Key]
        //[ForeignKey("Account")]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Account Account { get; set; }

        public IEnumerable<UserRole> UserRoles { get; set; }
    }
}
