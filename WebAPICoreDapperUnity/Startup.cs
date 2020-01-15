using IRepository.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySQLRepository;
using MySQLRepository.Repositories;
using ServiceImpletment;
using ServiceInterface;
using Unity;

namespace WebAPICoreDapperUnity
{
	public class Startup
	{
		public IConfiguration Configuration { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			//Ex:
			//services.Configure<AppConfig>(this.Configuration);

			services.AddDapperDBContext<SystemUserRepository>(options =>
			{
				options.ConnectionName = Configuration.GetSection("ConnectionName").Value;
				options.ConnectionString = Configuration.GetSection("MySQLConnectionString").Value;
			});
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}

		public void ConfigureContainer(IUnityContainer container)
		{
			// Could be used to register more types
			container.RegisterType<ISystemUserRepository, SystemUserRepository>();
			container.RegisterType<ISystemUserManager, SystemUserManager>();

			//container.RegisterType<IConnectionFactorySetting, ConnectionFactorySetting>();
		}
	}
}
