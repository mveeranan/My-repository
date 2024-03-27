using Microsoft.EntityFrameworkCore;

namespace StudentManagement_API.Models
{
	[Keyless]
	public class Response
	{
		public int? StatusCode { get; set; }
		public string? Message { get; set; }
		public dynamic? Data { get; set; }
	}
}
