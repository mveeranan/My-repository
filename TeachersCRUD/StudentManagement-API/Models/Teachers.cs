using System.ComponentModel.DataAnnotations;

namespace StudentManagement_API.Models
{
	public class Teachers
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Subject { get; set; }
	}
}
