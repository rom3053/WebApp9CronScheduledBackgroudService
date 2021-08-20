using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.AppDBContext;
using WebApp9CronScheduledBackgroudService.Server.BGService;
using WebApp9CronScheduledBackgroudService.Server.BGService.HostedService;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server
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
            services.AddDbContext<MyContext>(options =>
            {

                options.UseInMemoryDatabase("Test");
                //options.UseLoggerFactory(new LoggerFactory(new[] {
                //                                new Microsoft.Extensions.Logging.Debug.DebugLoggerProvider()
                //                                                    }));


            });

            services.AddScoped<IBackgroundContainer, BackgroundContainer>();

            services.AddScoped<IPromotionService, PromotionService>();
            services.AddScoped<ICampaignSender, CampaignSender>(a => new CampaignSender());
            services.AddScoped<IBackgroundCampaignSender, BackgroundCampaignSender>();
            services.AddSingleton<SchedulerService>();
            services.AddHostedService<ConsumeScopedHostedService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                FakeDataSeeder.Seed(serviceProvider);
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
