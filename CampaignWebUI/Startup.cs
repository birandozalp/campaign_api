using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignWebUI.APIs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace CampaignWebUI
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
            var baseUrl = "https://localhost:44325/";
            var baseUri = new Uri(baseUrl);

            services.AddRefitClient<IProductAPI>()
                    .ConfigureHttpClient(client => { client.BaseAddress = baseUri; });
            services.AddRefitClient<IOrderAPI>()
                   .ConfigureHttpClient(client => { client.BaseAddress = baseUri; });
            services.AddRefitClient<ITimeAPI>()
                   .ConfigureHttpClient(client => { client.BaseAddress = baseUri; });
            services.AddRefitClient<ICampaignAPI>()
                   .ConfigureHttpClient(client => { client.BaseAddress = baseUri; });



            services.AddControllersWithViews();
            services.AddMvc();



          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
                    pattern: "{controller=FileUpload}/{action=UploadFile}/{id?}");
            });
        }

    }
}
