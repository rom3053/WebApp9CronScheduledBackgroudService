using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public class SchedulerService
    {
        //private static List<Timer> _timers = new List<Timer>();
        private List<Timer> timers = new List<Timer>();
        private IServiceProvider _service;
        public SchedulerService(IServiceProvider serviceProvider) 
        {
            _service = serviceProvider;
            //using (var scope = serviceProvider.CreateScope())
            //{
            //    var scopedProcessingService = scope.ServiceProvider.GetRequiredService<IBackgroundCampaignSender>();
            //    double interval = 10.0 / 3600;
            //    ScheduleTask(DateTime.Now.Hour, DateTime.Now.AddMinutes(1).Minute, interval, () => scopedProcessingService.DoWorkStatus());
            //}
        }

        public  void IntervalInSeconds(int hour, int sec, double interval, Action task)
        {
            interval = interval / 3600;
            ScheduleTask(hour, sec, interval, task);
        }
        public  void IntervalInMinutes(int hour, int min, double interval, Action task)
        {
            interval = interval / 60;
            ScheduleTask(hour, min, interval, task);
        }
        public  void IntervalInHours(int hour, int min, double interval, Action task)
        {
            ScheduleTask(hour, min, interval, task);
        }
        public  void IntervalInDays(int hour, int min, double interval, Action task)
        {
            interval = interval * 24;
            ScheduleTask(hour, min, interval, task);
        }

        private void ScheduleTask(int hour, int min, double intervalInHour, Action task)
        {
            DateTime now = DateTime.Now;
            DateTime firstRun = new DateTime(now.Year, now.Month, now.Day, hour, min, 0, 0);
            if (now > firstRun)
            {
                firstRun = firstRun.AddDays(1);
            }
            TimeSpan timeToGo = firstRun - now;
            if (timeToGo <= TimeSpan.Zero)
            {
                timeToGo = TimeSpan.Zero;
            }
            var timer = new Timer(x =>
            {
                task.Invoke();
            }, null, timeToGo, TimeSpan.FromHours(intervalInHour));
            timers.Add(timer);
        }

    }
}
