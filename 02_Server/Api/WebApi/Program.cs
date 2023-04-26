using Identity.Models;
using Identity.Seeds;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace Webapi
{
	public class Program
	{
		public static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{

					//TODO: Registrar aqui servicios de insercion de registros iniciales
					//var userManager = services.GetRequiredService<UserManager<AplicationUser>>();
					//var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
					//await DefaultRoles.SeedAsync(userManager, roleManager);
					//await DefaultRootUser.SeedAsync(userManager, roleManager);
					//await DefaultAdminUser.SeedAsync(userManager, roleManager);
				}
				catch (Exception ex)
				{
					throw;
				}
			}

			host.Run();
            return Task.CompletedTask;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
