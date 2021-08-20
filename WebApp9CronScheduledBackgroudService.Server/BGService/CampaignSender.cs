using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp9CronScheduledBackgroudService.Server.BGService
{
    public class CampaignSender : ICampaignSender
    {
        public CampaignSender()
        {
            
        }

        
        public async Task SendEmailAsync(string toAddress, string body = null, string ccAddress = null)
        {
            if (string.IsNullOrEmpty(toAddress))
            {
                throw new ArgumentNullException("No recipient address have been configured.");
            }

            try
            {
                //repository for campaign

                //take users from DB

                //List<string> phoneList = new List<string>();
                //var customersFromTag = await _сontext.Tags.Where((t) => t.Id == "a512a14d-3257-4bb0-939d-be71cc62fcfa")
                //                                    .Include((c) => c.TagToCustomers)
                //                                    .ThenInclude((cs) => cs.Customer)
                //                                    .ToListAsync();

                //foreach (var item in customersFromTag)
                //{
                //    foreach (var tag in item.TagToCustomers)
                //    {
                //        phoneList.Add(tag.Customer.PhoneNumber);
                //    }
                //}


                //call whatsapp service send message
                Console.WriteLine(toAddress);
                Console.WriteLine($"Finished: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}

