using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyAPI.Controllers;
using UdemyAPI.Models;
using UdemyAPI.Services;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using UdemyAPI.Authentication;

namespace UdemyAPI
{
    public class Startup
    {
        //cors
        private readonly string enableCors = "cors";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
           // services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson(options =>
            //Looping Ignore
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //Nsawg Not Swagger
            services.AddSwaggerDocument();

            //ConfirmJWt
            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
              .AddJwtBearer(jwt =>
            {
                var key = Encoding.ASCII.GetBytes(Configuration["JWT:Key"]);
                jwt.SaveToken = true;
                jwt.RequireHttpsMetadata = false;
                jwt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey=true,

                    ValidIssuer=Configuration["JWT:Issuer"],
                    ValidAudience= Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(Configuration["JWT:Key"]))
                   
                };
            });


            //DBContext
            services.AddDbContext<UdemyContext>(options =>
            {
                options.UseLazyLoadingProxies()
                .UseSqlServer(Configuration.GetConnectionString("con1"));
                
            });

            //Identity
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UdemyContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(op=> {
                //No Duplication in Mail
                op.User.RequireUniqueEmail = true;
                //password  Change Later
                op.Password.RequiredLength = 8;
                op.Password.RequireDigit=false;
                op.Password.RequireLowercase=false;
                op.Password.RequireUppercase=false;
                op.Password.RequireNonAlphanumeric=false;

            });

            //DI
            services.AddTransient<IDB, DBService>();

            //CORS
            services.AddCors(c =>
            {
                //Allow All 
                c.AddPolicy(enableCors, c => 
                {
                    c.AllowAnyOrigin();
                    c.AllowAnyMethod();
                    c.AllowAnyHeader();

                });
            });

            //FilesOptions
            services.Configure<FormOptions>(o => {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });
            
        }


        //Middlewares
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            app.UseRouting();
            app.UseCors(enableCors);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
           
            
        }
    }
}
