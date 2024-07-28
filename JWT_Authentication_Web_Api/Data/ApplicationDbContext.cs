using JWT_Authentication_Web_Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace JWT_Authentication_Web_Api.Data
    {
    public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext(DbContextOptions options) : base(options)
            {

            }
            public DbSet<Users> users { get; set; }
        }
    }
