using System.ComponentModel.DataAnnotations;

namespace JWT_Authentication_Web_Api.Models
    {
    public class Login
        {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }

        }
    }
