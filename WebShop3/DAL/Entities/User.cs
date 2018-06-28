using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShop3.DAL.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string FullName { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Email { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Password { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string PasswordSalt { get; set; }
        public bool EmailConfirmed { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string EmailConfirmToken { get; set; }
        [StringLength(maximumLength: 255)]
        public string ForgotToken { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}