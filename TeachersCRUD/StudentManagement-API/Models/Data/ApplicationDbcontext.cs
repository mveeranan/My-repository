using Microsoft.EntityFrameworkCore;

namespace StudentManagement_API.Models.Data
{
	public class ApplicationDbcontext : DbContext
	{
		public ApplicationDbcontext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Teachers> teachers { get; set; }
	}
}
