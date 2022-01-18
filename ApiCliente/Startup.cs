using ApiCliente.Application;
using ApiCliente.Application.Interface;
using ApiCliente.Application.Interface.Mapper;
using ApiCliente.Application.Mapper;
using ApiCliente.Core.Interface.Repository;
using ApiCliente.Core.Interface.Service;
using ApiCliente.Domain.Validations;
using ApiCliente.Infrastructure.Data.Repository;
using ApiCliente.Infrastructure.Data.Repository.EF;
using ApiCliente.Service;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ApiCliente
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
            services.AddTransient<IAppServiceCliente, AppServiceCliente>();


            services.AddDbContext<SqlContext>(
              x => x.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
          );

            services.AddControllers();

            services.AddMvc().AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
            });

            services.AddMvc()
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<ClienteValidation>(lifetime: ServiceLifetime.Singleton))
                    .AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<CidadeValidation>(lifetime: ServiceLifetime.Singleton));



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiClientes", Version = "v1" });
            });


            services.AddHttpClient();
            services.AddScoped<IRepositoryCliente, ClienteRepository>();
            services.AddScoped<IAppServiceCliente, AppServiceCliente>();
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IMapperCliente, MapperCliente>();
            services.AddScoped<IRepositoryCidade, CidadeRepository>();
            services.AddScoped<IAppServiceCidade, AppServiceCidade>();
            services.AddScoped<IServiceCidade, ServiceCidade>();
            services.AddScoped<IMapperCidade, MapperCidade>();
            services.AddScoped<IAppViaCep, AppServiceViaCep>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiClientes v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiClientes V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
