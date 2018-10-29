using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore_PG_653
{
    public class Startup : IStartup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var appPartManager = new ApplicationPartManager();

            appPartManager.ApplicationParts.Add(new AssemblyPart(typeof(Startup).Assembly));

            services.Add(new ServiceDescriptor(typeof(ApplicationPartManager), appPartManager));

            return
                services
                    .AddEntityFrameworkNpgsql()
                    .AddDbContext<SomeDbContext>(
                        x => x.UseNpgsql("Host=localhost;Port=5432;"))
                    .AddMvcCore()
                    .AddJsonFormatters()
                    .Services
                    .BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<SomeDbContext>())
                {
                    Console.WriteLine(context.Database.ProviderName);
//                    context.Database.Migrate();
                }
            }

            app.UseMvc();
        }
    }
}