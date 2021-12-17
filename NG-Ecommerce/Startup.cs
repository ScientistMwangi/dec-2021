using EcommerceCore.DataLayer;
using EcommerceCore.DataLayer.Repository;
using EcommerceCore.Models.Users;
using EcommerceCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NG_Ecommerce.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NG_Ecommerce
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
            // AddCors
            services.AddCors();
            //services.AddCors(c =>
            //{
            //    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            //});
            // Dependancy Injection
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerOrderDetailRepo, CustomerOrderDetailRepo>();
            services.AddScoped<ICustomerOrderRepo, CustomerOrderRepo>();
            services.AddScoped<IEmailLogRepo, EmailLogRepo>();

            services.AddScoped<IEmailTemplateRepo, EmailTemplateRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IProductCategoryRepo, ProductCategoryRepo>();
            services.AddScoped<IProductTagRepo, ProductTagRepo>(); 

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            //Auto Mappers
            services.AddAutoMapper(typeof(Startup));

            // Context
            services.AddDbContext<EcommerceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")))
                    .AddIdentity<AppUser, Role>(options =>
                          // Default Password settings.
                          options.Password.RequireNonAlphanumeric = false

                        )
                    .AddEntityFrameworkStores<EcommerceDbContext>()
                    .AddDefaultTokenProviders();

            // Inject jwt settings from appsetting
            services.Configure<JwtSettings>(Configuration.GetSection("Jwt"));
            var jwtSettings = Configuration.GetSection("Jwt").Get<JwtSettings>();
            services.AddAuth(jwtSettings);

            services.AddControllers();
            // Swagger security
            var security =
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            },
                            UnresolvedReference = true
                        },
                        new List<string>()
                    }
                };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Test API",
                    Version = "v1",
                    Description = "Description for the API goes here.",
                    Contact = new OpenApiContact
                    {
                        Name = "The Scientist",
                        Email = string.Empty,
                        Url = new Uri("https://localhost:44371"),
                    },
                });

                // Security for swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT containing userid claim",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                // Add security config
                c.AddSecurityRequirement(security);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("http://localhost:90");
            app.UseCors("http://localhost:3000");
            // global cors policy
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            //app.UseAuthorization();
            app.UseAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"public\assests\")),
                        RequestPath = new PathString("/StaticFiles")
            });
            /*app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"public\assests\")),
                    RequestPath = new PathString("/StaticFiles")
            });*/

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
