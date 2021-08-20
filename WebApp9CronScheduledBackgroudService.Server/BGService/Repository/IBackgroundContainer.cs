using System.Linq;
using System.Threading.Tasks;

namespace WebApp9CronScheduledBackgroudService.Server.BGService.Repository
{
    public interface IBackgroundContainer
    {
        IQueryable<Promotions> GetPromotions();
        Task<Promotions> UpdatePromotion(Promotions promotions);
    }
}
