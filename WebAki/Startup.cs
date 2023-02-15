using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Telegram.Bot;
using Telegram.Bot.Types;
using WebAki.Enttines;
using Telegram.Bots.Extensions.Polling;

namespace WebAki
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServeces(IServiceCollection services)
        {
            services.AddControllers(); // создаём миграцию, что бы создать таблицу
            services.AddDbContext<DataCotext>(opt =>
                opt.UseSqlServer(_configuration
                    .GetConnectionString("Db"))); // хранит все таблици и настройки mappig с полями в базе данных
            services.AddSingleton<TelegrammBot>();


        }

        public class DataCotext : DbContext
        {
            public DataCotext(DbContextOptions<DataContext> options, DbSet<AppUser> users) : base(options)
            {
                Users = users;
            }

            public DbSet<AppUser> Users { get; set; }
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            IApplicationBuilder applicationBuilder1 = app.UseEndpoints(endpoins => { endpoins.MapControllers(); });
            IApplicationBuilder applicationBuilder = applicationBuilder1;
        }

        
      

       
        
    }

    
}
            


        
    
        