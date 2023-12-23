using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoManager.Context;
using TodoManager.Helper;
using TodoManager.Helper.Interfaces;
using TodoManager.Repositories;
using TodoManager.Repositories.Interfaces;

namespace TodoManager {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IPrioridadeRepository,PrioridadeRepository>();
            services.AddTransient<IStatusTarefaRepository, StatusTarefaRepository>();
            services.AddTransient<ISessao, Sessao>();

            services.AddSession(o => { 
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews()
                .AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. 
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                   name: "tarefa",
                   pattern: "Tarefa/{id?}",
                   defaults: new { controller = "Tarefa", action = "Index" }
               );
                endpoints.MapControllerRoute(
                 name: "Editar",
                 pattern: "Tarefa/Editar/{id?}",
                 defaults: new { controller = "Tarefa", action = "Editar" });
            });
        }
    }
}
