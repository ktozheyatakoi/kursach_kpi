using InventorySklad.Core.Item;
using InventorySklad.Core.Sklad;
using InventorySklad.Data;
using InventorySklad.Data.Item;
using InventorySklad.Data.Sklad;
using InventorySklad.Orchestrators.Item;
using InventorySklad.Orchestrators.Sklad;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InventorySklad.Onion
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            string connString = Configuration.GetConnectionString("SkladDB");
            services.AddDbContext<InventorySkladContext>(options => options.UseNpgsql(connString));

            services.AddAutoMapper(typeof(DaoItemProfile), typeof(DaoSkladProfile), typeof(ItemDaoProfile), typeof(SkladDaoProfile),
                typeof(OrchItemProfile), typeof(ItemOrchProfile), typeof(OrchSkladProfile), typeof(SkladOrchProfile));
            
            services.AddScoped<ISkladRepo, SkladRepository>();
            services.AddScoped<ISkladService, SkladService>();

            services.AddScoped<IItemRepo,ItemRepository>();
            services.AddScoped<IItemService, ItemService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "InventorySklad.Onion", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventorySklad.Onion v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}