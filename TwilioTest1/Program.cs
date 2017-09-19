using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your Account SID from twilio.com/console
            var accountSid = "ACd1fbc9165a5a2ad6df57e01a9708b73b";
            // Your Auth Token from twilio.com/console
            var authToken = "f36bf5c18f293acd5bae1ff1f34d512b";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                to: new PhoneNumber("+919953195514"),
                from: new PhoneNumber("+13219855413"),
                body: "Test Message fro Manoj");

            Console.WriteLine(message.Sid);
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
