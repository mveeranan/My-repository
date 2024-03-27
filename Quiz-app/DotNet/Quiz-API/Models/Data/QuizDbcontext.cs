using Microsoft.EntityFrameworkCore;

namespace Quiz_API.Models.Data
{
	public class QuizDbcontext : DbContext
	{
		public QuizDbcontext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<sample> samples { get; set; }
		public DbSet<Participant> participant { get; set; }
		public DbSet<Question> question { get; set; }
	}
}
