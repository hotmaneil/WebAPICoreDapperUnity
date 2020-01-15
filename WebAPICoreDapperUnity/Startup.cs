using IRepository.IRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MySQLRepository;
using MySQLRepository.Repositories;
using ServiceImpletment;
using ServiceInterface;
using System;
using System.IO;
using System.Reflection;
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

			// Register the Swagger generator, defining 1 or more Swagger documents
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "My API",
					Version = "v1",
					Description = "ASP.NET Core Web API結合Unity.Microsoft.DependencyInject,Dapper.SimpleCRUD之範本"
				});

				// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
			// specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});

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
