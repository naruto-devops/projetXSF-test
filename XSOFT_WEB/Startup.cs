using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Repositories.Contracts;
using Reposiotries.Implementations;
using Newtonsoft.Json.Serialization;
using Repositories.Implementations;
using Services.Contracts;
using Services;
using Services.Implementations;

namespace XSOFT_WEB
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
             services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc()
             .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });
            #region repo
            services.AddScoped<IArticleGeneriqueRepository, ArticleGeneriqueRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IFournisseurRepository, FournisseurRepository>();
            services.AddScoped<IFamilleTierRepository, FamilleTierRepository>();
            services.AddScoped<ICategorieTarifRepository, CategorieTarifRepository>();
            services.AddScoped<IDeviseRepository, DeviseRepository>();
            services.AddScoped<ICollaborateurRepository, CollaborateurRepository>();
            services.AddScoped<IModalitePaiementRepository, ModalitePaiementRepository>();
            services.AddScoped<IIncotermRepository, IncotermRepository>();
            #endregion

            #region services
            services.AddScoped<ICollaborateurService, CollaborateurServices>();
            services.AddScoped<IDeviseService, DeviseServices>();
            services.AddScoped<IFamilleTierService, FamilleTierServices>();
            services.AddScoped<ICategorieTarifService, CategorieTarifServices>();
            services.AddScoped<IModalitePaiementService, ModalitePaiementServices>();
            services.AddScoped<IIncotermService, IncotermServices>();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
