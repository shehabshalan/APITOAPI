using Microsoft.EntityFrameworkCore;

namespace AnotherAPI.Data
{
    public class DataContext : DbContext

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Postcode> Postcodes { get; set; }
    }
}
