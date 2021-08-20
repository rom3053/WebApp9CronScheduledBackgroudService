using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public class PromotionService : IPromotionService
    {
        private readonly IBackgroundContainer _repository;
        public PromotionService(IBackgroundContainer repository)
        {
            _repository = repository;

        }
        public Task<IQueryable<Promotions>> GetPromotions()
        {
            return Task.Run(() => _repository.GetPromotions());
        }
        public Task<Promotions> UpdatePromotions(Promotions promotions)
        {
            return Task.Run(() => _repository.UpdatePromotion(promotions));
        }
    }
}
