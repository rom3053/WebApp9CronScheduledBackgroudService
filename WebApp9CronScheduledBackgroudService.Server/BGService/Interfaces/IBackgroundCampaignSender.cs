using System.Threading.Tasks;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public interface IBackgroundCampaignSender
    {
        Task DoWork();
        Task DoWorkStatus();
    }
}