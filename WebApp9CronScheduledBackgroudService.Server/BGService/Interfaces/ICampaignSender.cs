using System.Threading.Tasks;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public interface ICampaignSender
    {
        Task SendEmailAsync(string toAddress, string body = null, string ccAddress = null);
    }
}