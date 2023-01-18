using Microsoft.EntityFrameworkCore;

namespace Receipt_Generator.Data
{
    public class ReceiptDbContext : DbContext
    {
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-2NA2N4M\\SQLEXPRESS;Database=Receipt;Trusted_Connection=true; MultipleActiveResultSets=true;");
        }
        public DbSet<Models.Receipt> Receipt{ get; set; }
    }
    

}
