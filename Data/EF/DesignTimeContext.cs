using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.EF
{
    public class DesignTimeContext : IDesignTimeDbContextFactory<DBContext>
    {
        public DBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=DBContext;Integrated Security=True");
            return new DBContext(optionsBuilder.Options);
        }
    }
}
