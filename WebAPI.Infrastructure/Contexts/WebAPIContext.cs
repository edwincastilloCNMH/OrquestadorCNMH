using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Infrastructure.Helpers;
using WebAPI.Infrastructure.Models;

namespace WebAPI.Infrastructure.Contexts
{
	public class WebAPIContext : DbContext
	{
		public IConfiguration configuration { get; set; }


		public WebAPIContext()
        {
			configuration = AppSettings.GetConfiguration();
		}

		public WebAPIContext(DbContextOptions<WebAPIContext> options) : base(options)
		{
			configuration = AppSettings.GetConfiguration();
		}

        public DbSet<SourceConfig> SourceConfig { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<ModelType> ModelType { get; set; }
        public DbSet<SourceModel> SourceModel { get; set; }
        public DbSet<SourceModelFields> SourceModelFields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlserverConnection"));
		}
	}
}
