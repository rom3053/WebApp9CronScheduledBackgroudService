using System;
using WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension;

namespace WebApp9CronScheduledBackgroudService.Server.BGService.Repository
{

    public class Promotions
    {
        public int Id { get; internal set; }
        public string ClientId { get; set; }
        //public virtual Client Client { get; set; }
        public string TemplateId { get; set; }
        //public virtual Template Template { get; set; }
        public string TagId { get; set; }
        //public virtual Tag Tag { get; set; }





        public string Name { get; internal set; }
        public string Cron { get; set; }
        public RecurringJob ReccuringJob { get; set; }
        public bool CompletedToday { get; set; } = false;
        public bool Enabled { get; set; } = true;



        public DateTime StartDate { get; internal set; }

    }

}