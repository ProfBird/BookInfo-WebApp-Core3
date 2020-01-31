using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GoodBookNook.Repositories
{
    public class MySqlDbContext : AppDbContext
    {
        public MySqlDbContext(IConfiguration configuration) : base(configuration)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to MariaDb or MySql database
            options.UseMySql(Config["ConnectionStrings:MySqlConnection"]);
        }
    }
}