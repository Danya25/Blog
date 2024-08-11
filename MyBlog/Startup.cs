using System;
using System.Reflection;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MyBlog.Common.Mapper;
using MyBlog.Common.Models;
using MyBlog.DAL;
using MyBlog.Middleware;
using MyBlog.Services;
using MyBlog.Services.Auth;
using MyBlog.Services.JWT;

namespace MyBlog
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy("Cors", builder =>
                {
                    builder.SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });
            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddServices();

            var mySecurityKey = Configuration.GetSection("Key");
            services.Configure<SymmetricKey>(opt =>
            {
                opt.Key = mySecurityKey.Value;
            });

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtGenerator, JwtGenerator>();

            services.AddAuthentication(t =>
            {
                t.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                t.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                t.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(mySecurityKey.Value)),

                    ValidateAudience = false,
                    ValidateIssuer = false,

                    ValidateLifetime = true,

                    ClockSkew = TimeSpan.FromSeconds(10)
                };
            });

            services.AddControllers();
            
            services.AddSwaggerGen(c =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. " +
                                     "You should request JWT token using login endpoints.",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                };
                c.AddSecurityDefinition("token", securityScheme);
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "token"}
                        },
                        Array.Empty<string>()
                    }
                };
                c.AddSecurityRequirement(securityRequirement);
                
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyBlog", Version = "v1" });
                c.EnableAnnotations();
                c.DescribeAllParametersInCamelCase();
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyBlog v1");
                    c.DefaultModelsExpandDepth(0);
                });
            }
            
            app.UseHttpsRedirection();

            app.UseCors("Cors");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ApiExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
