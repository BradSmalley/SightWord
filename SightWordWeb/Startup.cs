using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR;
using SightWordWeb.Hubs;
using SightWordWeb.Models;

namespace SightWordWeb
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
            services.AddMvc();
            services.AddSignalR();
            services.Add(new ServiceDescriptor(typeof(MyService), new MyService()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSignalR(routes =>
            {
                routes.MapHub<WordHub>("/WordHub");
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    public class MyService 
    {
        public WordList<Word> TestWordList = new WordList<Word>();

        public MyService()
        {
            TestWordList.Add(new Word("One"));
            TestWordList.Add(new Word("Two"));
            TestWordList.Add(new Word("Three"));
            TestWordList.Add(new Word("Four"));
            TestWordList.Add(new Word("Five"));
            TestWordList.Add(new Word("Six"));
        }

    }

}
