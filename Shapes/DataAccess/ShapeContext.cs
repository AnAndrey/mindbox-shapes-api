using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shapes.Config;

namespace Shapes.DataAccess
{
    public class ShapeContext : DbContext
    {
        private readonly DatabaseConfig _databaseConfig;

        public DbSet<ShapeDto> Shapes { get; set; }

        public ShapeContext(IOptionsMonitor<DatabaseConfig> optionsMonitor)
        {
            _databaseConfig = optionsMonitor.CurrentValue;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite(_databaseConfig.ConnectionString);
    }
}
