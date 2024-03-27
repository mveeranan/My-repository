using Microsoft.EntityFrameworkCore;
using StudentsCRUD.Models;

namespace StudentsCRUD.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Students> Students { get; set; }
    }
}
