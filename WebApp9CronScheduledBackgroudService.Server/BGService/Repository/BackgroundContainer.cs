using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.CronExtension;
using WebApp9CronScheduledBackgroudService.Server.AppDBContext;

namespace WebApp9CronScheduledBackgroudService.Server.BGService.Repository
{
    public class BackgroundContainer : IBackgroundContainer
    {
        private List<Promotions> Promotions { get; set; } = new List<Promotions>();
        private MyContext _context;
        
        public BackgroundContainer(MyContext context)
        {

            _context = context;
            //for (var i = 0; i <= 100; i++)
            //{
            //    Promotions.Add(new Promotions
            //    {
            //        Id = i,
            //        Name = $"Promotion {i}",
            //        Cron = DateTime.Now.AddSeconds(i * 10).ToCron(),
            //        EndDate = DateTime.Now.AddSeconds(i * 10)
            //    }) ;
            //}
        }
        protected virtual IQueryable<Promotions> GetQueryable()
        {
            IQueryable<Promotions> query = _context.Set<Promotions>();
            query = query.Where(x => x.Enabled == true);

            return query.AsNoTracking();
        }
        public IQueryable<Promotions> GetPromotions()
        {
            return GetQueryable();
        }
        public async Task<Promotions> UpdatePromotion(Promotions promotions)
        {
            _context.Update(promotions);
            await _context.SaveChangesAsync();
            return promotions;
        }
    }
}
