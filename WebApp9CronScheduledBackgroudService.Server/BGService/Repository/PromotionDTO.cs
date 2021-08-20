using WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension;

namespace WebApp9CronScheduledBackgroudService.Server.BGService.Repository
{
    public class PromotionDTO
    {
        public string ID { get; set; }
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
