using System;
using GloboTicket.Web.Services;
using GloboTicket.Web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GloboTicket.Grpc;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using GloboTicket.Messages;
using Microsoft.Azure.Storage;

namespace GloboTicket.Web
{
    public class Startup
    {
        private readonly IHostEnvironment environment;
        private readonly IConfiguration config;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            config = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddControllersWithViews();

            if (environment.IsDevelopment())
                builder.AddRazorRuntimeCompilation();

          /*  services.AddHttpClient<IEventCatalogService, EventCatalogService>(c =>  
                c.BaseAddress = new Uri(config["ApiConfigs:EventCatalog:Uri"]));*/
            services.AddHttpClient<IShoppingBasketService, ShoppingBasketService>(c => 
                c.BaseAddress = new Uri(config["ApiConfigs:ShoppingBasket:Uri"]));
          
            services.AddGrpcClient<Events.EventsClient>(o => o.Address = new Uri(config["ApiConfigs:EventCatalog:Uri"]));

            services.AddSingleton<Settings>();
            var storageAccount = CloudStorageAccount.Parse(config["AzureQueues:ConnectionString"]);
            services.AddRebus(c => c.Transport(t => t.UseAzureStorageQueuesAsOneWayClient(storageAccount)).
            Routing(r => r.TypeBased().Map<PaymentRequestMessage>(config["AzureQueues:QueueName"])));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=EventCatalog}/{action=Index}/{id?}");
            });
        }
    }
}