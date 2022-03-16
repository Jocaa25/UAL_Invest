using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UAL_Invest.Context;
using UAL_Invest.Repositorio.Data;
using UAL_Invest.Repositorio.Interface;

namespace UAL_Invest
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
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer().AddDbContext<UalContext>(o => o.UseSqlServer(Configuration.GetConnectionString("ServerConnnection")));



            services.AddSession();

            services.AddScoped<ICadastroUsuarioRepositorio, CadastroUsuarioRepositorio>();
            services.AddScoped<ICadastroGerenteRepositorio, CadastroGerenteRepositorio>();
            services.AddScoped<ICadastroAtivoRepositorio, CadastroAtivoRepositorio>();
            services.AddScoped<IClienteDepositoRepositorio, ClienteDepositoRepositorio>();
            services.AddScoped<ILoginRepositorio, LoginRepositorio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseSession();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
