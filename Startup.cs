using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using WebapiMaestros.Services;
using WebapiMaestros.Services.Interfaces;
using WebapiMaestros.Data;
using WebapiMaestros.Data.Interfaces;
using WebapiMaestros.Domain;
using WebapiMaestros.Mapper;
using System;
using System.IO;
using System.Reflection;

namespace WebapiMaestros
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

         services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
         {
            builder.WithOrigins("*", "*", "*").AllowAnyMethod().AllowAnyHeader();
         }));


         //AutoMapper
         services.AddScoped(provider => new MapperConfiguration(mc =>
         {
            mc.AddProfile(new MappingProfile());
         }).CreateMapper());
         services.AddMvc();

         //Swagger
         services.AddSwaggerGen(c =>
         {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "API Rest Maestros", Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
               Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
               Name = "Authorization",
               In = ParameterLocation.Header,
               Type = SecuritySchemeType.ApiKey,
               Scheme = "Bearer"

            });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

         });

         //Inyeccion de dependencias
         EstablecerServiciosParaInyeccion(ref services);

         
         
      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();

            //Configurar swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
               c.SwaggerEndpoint("v1/swagger.json", "MaestrosAPI V1");
               //c.OAuthClientId("ec5932b7 - b448 - 496e-af31 - f121c5383b01");
            });
         }
         else
         {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
         }

         app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

         app.UseHttpsRedirection();
         app.UseStaticFiles();

         app.UseRouting();

         app.UseAuthorization();

         app.UseEndpoints(endpoints =>
         {
            endpoints.MapControllerRoute(
                   name: "default",
                   pattern: "{controller=Home}/{action=Index}/{id?}");
         });
      }

      private void EstablecerServiciosParaInyeccion(ref IServiceCollection services)
      {
         //Transient: Se instancian cada vez que se solicitan por cada clase
         //Singleton: Se comparte una única instancia para todas las peticiones http
         //Scoped: Se comparte una instancia entre las clases de cada petición http

         services.AddScoped<IStarWarsService, StarWarsService>();
         services.AddScoped<IStarWarsData, StarWarsData>();

         services.AddTransient<StarWarsContext, StarWarsContext>();
      }
   }
}
