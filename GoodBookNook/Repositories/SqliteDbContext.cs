using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GoodBookNook.Repositories
{
    public class SqliteDbContext : AppDbContext
    {
        public SqliteDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Config["ConnectionStrings:SQLiteConnection"]);
        }
    }
}