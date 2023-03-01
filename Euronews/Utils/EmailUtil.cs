using System;
using System.Collections.Generic;
using Euronews.Models;
using Aquality.Selenium.Browsers;
using Euronews.Framework;

namespace Euronews.Utils
{
    public static class EmailUtil
    {
        public static string WaitForEmail(GmailApi client, string sender, float minutesToWait, int pollingIntervalSeconds)
        {
            var emailsBeforeResponse = client.GetAllEmails(sender);
            var emailsBeforeList = JsonUtil.GetEmailsList(emailsBeforeResponse.Content);
            List<Message> emailsAfterList = null;
            var emailsAmountBefore = emailsBeforeList.Count;
            var emailsAmountAfter = 0;
            string confirmationEmailId = string.Empty;
            AqualityServices.ConditionalWait.WaitFor(() =>
            {
                if (emailsAmountAfter > emailsAmountBefore)
                {
                    confirmationEmailId = emailsAfterList[0].id;
                    return true;
                }
                else
                {
                    try
                    {
                        var emailsAfterResponse = client.GetAllEmails(sender);
                        emailsAfterList = JsonUtil.GetEmailsList(emailsAfterResponse.Content);
                        emailsAmountAfter = emailsAfterList.Count;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    return false;
                }
            }, timeout: TimeSpan.FromMinutes(minutesToWait), pollingInterval: TimeSpan.FromSeconds(pollingIntervalSeconds));
            return confirmationEmailId;
        }
    }
}
