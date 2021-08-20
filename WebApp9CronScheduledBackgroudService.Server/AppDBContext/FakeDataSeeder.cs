using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server.AppDBContext
{
    public class FakeDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new MyContext(
                        serviceProvider
                        .GetRequiredService<DbContextOptions<MyContext>>()))
            {
                DateTime dateTime = DateTime.Now;
                for (var i = 0; i <= 59; i++)
                {
                    context.Promotions.Add(new Promotions
                    {
                        Name = $"Promotion  Weekly {i}",
                        Cron = new DateTime(2021, 8, 12, dateTime.Hour, i, i).ToCron(RecurringJob.Weekly),
                        StartDate = new DateTime(2021, 8, 10, dateTime.Hour, i, i)
                    });
                    context.Promotions.Add(new Promotions
                    {
                        Name = $"Promotion Daily {i}",
                        Cron = new DateTime(2021, 8, 10, dateTime.Hour, i, i).ToCron(),
                        StartDate = new DateTime(2021, 8, 10, dateTime.Hour, i, i)
                    });
                    context.Promotions.Add(new Promotions
                    {
                        Name = $"Promotion Daily {i}",
                        Cron = new DateTime(2021, 8, 10, 15, i, i).ToCron(),
                        StartDate = new DateTime(2021, 8, 10, 15, i, i)
                    });
                    context.Promotions.Add(new Promotions
                    {
                        Name = $"Promotion Once {i}",
                        Cron = new DateTime(2021, dateTime.Month, dateTime.Day, dateTime.Hour, i, i).ToCron(RecurringJob.Once),
                        StartDate = new DateTime(2021, 8, 10, 15, i, i)
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
