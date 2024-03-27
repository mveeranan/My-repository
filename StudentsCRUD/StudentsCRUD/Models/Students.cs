using System.ComponentModel.DataAnnotations;

namespace StudentsCRUD.Models
{
    public class Students
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
