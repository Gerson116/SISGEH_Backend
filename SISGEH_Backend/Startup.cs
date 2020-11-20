using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SISGEH_Backend.Context;
using SISGEH_Backend.DTOs;
using SISGEH_Backend.Entities;
using SISGEH_Backend.Services.SEncriptando;
using SISGEH_Backend.Services.SPersonalDeLaEmpresa;

namespace SISGEH_Backend
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
            services.AddDataProtection();
            services.AddTransient<ICRUD_Personal, CRUD_Personal>();
            services.AddTransient<IHashService, HashService>();

            services.AddDbContext<SISGEH_DbContext>(options=>
                options.UseSqlServer(Configuration.GetConnectionString("Db_SISGEH")));

            //Autenticación por JWT.
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters 
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"])),
                ClockSkew = TimeSpan.Zero
            });

            //Asignando Cors al proyecto.
            services.AddCors(options =>
            {
                options.AddPolicy("PermitirApiRequest", builder =>
                    builder.WithOrigins("https://localhost:44393").WithMethods("*")
                );
            });

            //... Mapeando objetos
            services.AddAutoMapper(configuration => 
            {
                configuration.CreateMap<PersonalDeLaEmpresaDTO, PersonalDeLaEmpresa>();
                configuration.CreateMap<PersonalDeLaEmpresa, PersonalDeLaEmpresaDTO>();
            }, typeof(Startup));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors();

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
