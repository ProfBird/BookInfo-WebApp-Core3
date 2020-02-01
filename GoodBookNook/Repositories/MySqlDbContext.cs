using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GoodBookNook.Repositories
{
    public class MySqlDbContext : AppDbContext
    {
        private IConfiguration config;
        public MySqlDbContext(IConfiguration configuration) : base(configuration)
        {
            config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to MariaDb or MySql database
            options.UseMySql(config["ConnectionStrings:MySqlConnection"]);
        }
    }
}