using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using IdentityServer4.AccessTokenValidation;
using LogisticBooking.API.ConfigHelpers;
using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using LogisticBooking.Persistence.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using StructureMap;
using Swashbuckle.AspNetCore.Swagger;

namespace LogisticBooking.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _environment;

        
        
        public Startup(IHostingEnvironment env, IConfiguration config)
        {
            _configuration = config;
            _environment = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            
            services.Configure<FrontendServerConfiguration>(
                _configuration.GetSection(nameof(FrontendServerConfiguration)));
            services.Configure<IdentityServerConfiguration>(
                _configuration.GetSection(nameof(IdentityServerConfiguration)));

            IdentityModelEventSource.ShowPII = true;

            var identityServer = _configuration.GetSection(nameof(IdentityServerConfiguration))
                .Get<IdentityServerConfiguration>();
            
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = $"{identityServer.IdentityServerUrl}";
                    options.RequireHttpsMetadata = true;
                    options.ApiName = "logisticbookingapi";
                });
            
   

            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            // Swagger added
            
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Management.API Auth", new OAuth2Scheme
                {
                    Type = "oauth2",
                    Flow = "application",
                    Description = "This API uses the Management.API login Oauth2 Client Credentials flow",
                    TokenUrl = "https://qa-auth-management-identity.azurewebsite.net/connect/token",
                    Scopes = new Dictionary<string, string> { { "scope.fullacces", "Acces to all api-endpoints" } }
                });
                c.SwaggerDoc("v1", new Info { Title = "Management Backend", Version = "v1", Description = "Management API for use with prior agreement" });
            });
            
            
            var connectionString =
                "Server=tcp:logistictechnologies.database.windows.net,1433;Initial Catalog=test;Persist Security Info=False;User ID=LG_admin;Password=Hjallesevej50;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
           // services.AddDbContext<UtilityContext>(o => o.UseSqlServer(connectionString));

            
            // Add webRigistry
            
            var container = new Container(new WebRegistry.WebRegistry());
            
            
            FluentMapper.Initialize(options =>
            {
                options.AddMap(new TransporterMap());
                options.AddMap(new SupplierMap()); 
                options.AddMap(new RegistationsKeyMap());
                options.AddMap(new BookingMap());
                options.AddMap(new OrderMap());
                options.AddMap(new UtilBookingMap());
                options.ForDommel();
            });
            
            
            //The head of the container or dependency-injection tree has been set to the WebRegistry which conviniently includes, our MessaginRegistry and the tree will be build until there are no further registries to include.
            //Start configuration by using structuremap configure API
            container.Configure(config =>
            {
                //Start registering stuff in container, stuff is defined from the included registries. The stuff is registered at our service, so they are at our disposal.
                config.Populate(services);
            });
            
            //Assert validation. This tries a full test, to see if all the configuration are truely valid, and can be configured
            container.AssertConfigurationIsValid();

            // We need to change the method return type from void to IServiceProvider. This makes
            // ASP.NET use the StructureMap container to resolve its dependencies.
            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            //Enabled API to deliver swagger UI on http://{serverUrl}/swagger;
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
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

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}