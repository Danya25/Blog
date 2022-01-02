using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Domain.DTO
{
    public sealed class UserRegistrationDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Username")]
        [MaxLength(15, ErrorMessage = "Username must not be longer than 15 characters. ")]
        public string DisplayName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
