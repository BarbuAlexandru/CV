using Microsoft.Extensions.Configuration;
using System.Linq;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace UnblockMe_App.Services
{
    public class ContactService
    {
        private string accountSid;
        private string authToken;
        private string messagingServiceSid;

        public ContactService(IConfiguration configuration)
        {
            accountSid = configuration.GetSection("Twilio").GetChildren().FirstOrDefault(section => section.Key == "accountSid").Value;
            authToken = configuration.GetSection("Twilio").GetChildren().FirstOrDefault(section => section.Key == "authToken").Value;
            messagingServiceSid = configuration.GetSection("Twilio").GetChildren().FirstOrDefault(section => section.Key == "messagingServiceSid").Value;
            TwilioClient.Init(accountSid, authToken);
        }

        //Services
        public void SendSMS(string phoneNumber, string msg)
        {
            var messageOptions = new CreateMessageOptions(
                new PhoneNumber(phoneNumber));
            messageOptions.MessagingServiceSid = messagingServiceSid;
            messageOptions.Body = msg;

            var message = MessageResource.Create(messageOptions);
        }

        public void SendEmail(string email, string msg)
        {
            //  Not implemented
            //      because i dont want to add additional NuGet packages or other services
            //      into the application or create random accounts to online services.
            //  Similar to the SMS service.
        }
    }
}
