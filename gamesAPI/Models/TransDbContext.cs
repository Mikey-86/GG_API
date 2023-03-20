using Microsoft.EntityFrameworkCore;

namespace gamesAPI.Models
{
    public class TransDbContext : DbContext
    {
        public TransDbContext(DbContextOptions<TransDbContext> options) : base(options) {
        }

        public DbSet<Translations> Translations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-24FMCT49\\SQLEXPRESS;Initial Catalog=TranslationsDB;Integrated Security=True;Encrypt=False");
        }
    }
}
