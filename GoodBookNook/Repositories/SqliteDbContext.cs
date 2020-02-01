using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GoodBookNook.Repositories
{
    public class SqliteDbContext : AppDbContext
    {
        private IConfiguration config;
        public SqliteDbContext(IConfiguration configuration) : base(configuration)
        {
            config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(config["ConnectionStrings:SQLiteConnection"]);
        }
    }
}