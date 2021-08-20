using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public interface IPromotionService
    {
        Task<IQueryable<Promotions>> GetPromotions();
        Task<Promotions> UpdatePromotions(Promotions promotions);
    }
}