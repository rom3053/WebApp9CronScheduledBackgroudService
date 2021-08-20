using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public class BackgroundCampaignSender : IBackgroundCampaignSender
    {

        private readonly IPromotionService _service;
        private readonly ICampaignSender _campaignService;

        public BackgroundCampaignSender(IPromotionService service, ICampaignSender campaignService)
        {
            _campaignService = campaignService;
            _service = service;
            //CronExtension.CronExtension.TIME_RANGE = 15;
        }

        public async Task DoWork()
        {
            DateTime timeNow = DateTime.Now;
            var promotions = await _service.GetPromotions();
            

            var soonToStart = promotions.Where(p => p.Enabled == true
                                                    && p.CompletedToday == false 
                                                    && timeNow.v2CompareCron(p.Cron) 
                                                   /* && p.v2CheckStatusCompleted(timeNow)*/);
                                                   
            if (soonToStart.Any())
            {
                foreach (var item in soonToStart)
                {
                    await _campaignService.SendEmailAsync($"n.campusanov@gmail.com {item.Name} {item.Id}");
                    item.CompletedToday = true;
                    await _service.UpdatePromotions(item);
                }
                //update context

            }
        }

        public async Task DoWorkStatus()
        {
            DateTime timeNow = DateTime.Now;
            var promotions = await _service.GetPromotions();
            var changeStatus = promotions.Where(p => p.Enabled == true &&
                                         p.CompletedToday == true 
                                         //&& p.v2CheckStatusCompleted(timeNow)
                                         );

            if (changeStatus.Any())
            {
                foreach (var item in changeStatus)
                {
                    if (item.ReccuringJob != RecurringJob.Once)
                    {
                        item.CompletedToday = CronExtension.CronExtension.v2ChangeStatus(timeNow, item.Cron);
                        await _service.UpdatePromotions(item);
                    }
                    
                }
                //context update
            }
        }
    }

}

