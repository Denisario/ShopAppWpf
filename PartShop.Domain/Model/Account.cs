using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    public class Account:DomainObject
    {
        [Key]
        public override int Id { get; set; }
        [Range(5,20, ErrorMessage = "Имя должно быть более 5 и менее 20 символов")]
        public string Username { get; set; }
        [Range(8, 15, ErrorMessage = "Пароль должен быть не менее 8 не более 15 символов")]
        public string Password { get; set; }
        [RegularExpression(@"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверный формат email")]
        public string Email { get; set; }
        public DateTime CreationTime { get; set; }
        public double Balance { get; set; }
        public List<Order> Orders { get; set; }
        public Role UserRole { get; set; }
        public List<Cart> Carts { get; set; }

        public Account()
        {
            Carts = new List<Cart>();
        }
    }
}
