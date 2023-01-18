using Microsoft.EntityFrameworkCore;

namespace Receipt_Generator.Data
{
    public class WebDbContext : DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2NA2N4M\\SQLEXPRESS;Database=Receipt;Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
        public DbSet<Receipt_Generator.Models.Receipt> Receipt { get; set; }
    }
    

}
