using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension;

namespace WebApp9ScheduledTaskBackgroundService.BGService.Repository
{
    public class PromotionCreateDTO
    {
        public string Name { get; set; }

        public string TagId { get; set; }
        public string TagName { get; set; }

        public string TemplateId { get; set; }
        public string TemplateName { get; set; }

        public string Time { get; set; }
        public RecurringJob ReccuringJob { get; set; }
        public bool Enabled { get; set; }
    }
}
