using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Identity.Data
{
    public class DesignTimeIdentityContext : IDesignTimeDbContextFactory<DBIdentityContext>
    {
        public DBIdentityContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBIdentityContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=DBIdentityContext;Integrated Security=True");
            return new DBIdentityContext(optionsBuilder.Options);
        }
    }
}
