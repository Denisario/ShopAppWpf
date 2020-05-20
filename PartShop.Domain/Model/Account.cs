using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PartShop.Domain.Model
{
    [Table("Accounts")]
    public class Account:DomainObject
    {
        [Key]
        [Column("id")]
        public override int Id { get; set; }
        [Required(ErrorMessage = "Имя пользователя обязательно")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Имя должно быть более 5 и менее 20 символов")]
        [Column("username")]
        public string Username { get; set; }
        [Column("pass")]
        [Required(ErrorMessage = "Пароль обязателен")]
        public string Password { get; set; }
        [Column("email")]
        [Required(ErrorMessage = "Электронная почта обязательна")]
        [RegularExpression(@"^([a-zA-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$", ErrorMessage = "Неверный формат email")]
        public string Email { get; set; }
        [Column("creation_date")]
        public DateTime CreationTime { get; set; }
        [Column("balance")]
        public double Balance { get; set; }
        public List<Order> Orders { get; set; }
        [Column("role")]
        public Role UserRole { get; set; }
        public List<Cart> Carts { get; set; }

        public Account()
        {
            Carts = new List<Cart>();
        }
    }
}
