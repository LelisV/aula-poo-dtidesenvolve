using BancoColumbia.Api;
using BancoColumbia.Api.Repositorios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BancoColumbia
{
    public class Startup
    {
        private const string TITULO_APP = "Banco Columbia";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var usuarioRepositorio = new UsuarioRepositorio();
            var contaBancariaRepositorio = new ContaBancariaRepositorio();

            services.AddSingleton(typeof(IUsuarioRepositorio), usuarioRepositorio);
            services.AddSingleton(typeof(IContaBancariaRepositorio), contaBancariaRepositorio);
            services.AddSingleton(typeof(CadastrarUsuarioExecutor), new CadastrarUsuarioExecutor(usuarioRepositorio));
            services.AddSingleton(typeof(CriarContaBancariaExecutor), new CriarContaBancariaExecutor(usuarioRepositorio, contaBancariaRepositorio));
            services.AddSingleton(typeof(AtualizarSaldoExecutor), new AtualizarSaldoExecutor(usuarioRepositorio, contaBancariaRepositorio));

            services.AddSwaggerGen(c =>
            {
                c.OrderActionsBy((apiDesc) => apiDesc.RelativePath);
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = TITULO_APP,
                    Description = "Sistema para o banco Columbia",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UsePathBase("/columbia");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/columbia/swagger/v1/swagger.json", TITULO_APP);
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
