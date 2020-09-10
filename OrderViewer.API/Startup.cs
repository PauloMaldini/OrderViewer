using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using OrderViewer.API.Swagger.Filters;
using OrderViewer.Core.Contexts;
using OrderViewer.Core.Entities;
using OrderViewer.Core.Interfaces;
using OrderViewer.Core.Reports;

namespace OrderViewer.API
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
            services.AddControllers(opts =>
                {
                    opts.ReturnHttpNotAcceptable = true;
                })
                .AddJsonOptions(opts => opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddXmlDataContractSerializerFormatters();
            
            services.AddDbContext<OrderViewerContext>(
                builder => builder.UseSqlite("Filename=OrderViewer.db"));
            
            services.AddScoped<IRepository<Order, OrderFilter, long>, OrderRepository>();
            services.AddScoped<IRepository<OrderItem, OrderItemFilter, long>, OrderItemRepository>();
            services.AddScoped<IRepository<Product, ProductFilter, long>, ProductRepository>();
            services.AddScoped<IReadCollection<OrderSummary, OrderSummaryFilter>, OrderSummaryReport>();
            
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "ORDERVIEWER API", Version = "v1" });

                var xmlDocFileName = Path.Combine(AppContext.BaseDirectory, 
                    $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
                x.IncludeXmlComments(xmlDocFileName);

                x.OperationFilter<ResponseHeaderOperationFilter>();
            });
                
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            services.AddCors(o => o.AddPolicy("Policy", builder =>
            {
                builder.SetIsOriginAllowed((host) => true)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(opts =>
            {
                opts.SwaggerEndpoint("/swagger/v1/swagger.json", "ORDERVIEWER API");
                opts.RoutePrefix = "";
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors("Policy");

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}