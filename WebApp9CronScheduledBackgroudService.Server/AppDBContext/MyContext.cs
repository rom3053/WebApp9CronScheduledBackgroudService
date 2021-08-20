using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp9CronScheduledBackgroudService.Server.BGService.Repository;

namespace WebApp9CronScheduledBackgroudService.Server.AppDBContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        { }
        public DbSet<Promotions> Promotions { get; set; }
    }
}
