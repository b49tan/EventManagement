using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio; 
namespace EventMan.Logic
{
    public static class SMSSender
    {
        // Find your Account Sid and Auth Token at twilio.com/user/account 
        public static string AccountSid = "ACe599f4b08150f786214d2d670d72e621";
        public static string AuthToken = "86b4b4f2eb4727f14374d030b2e3ab4d";

        public static void sendMessage(long? Mobile)
        {
            TwilioRestClient twilio = new TwilioRestClient(AccountSid, AuthToken);
            twilio.SendSmsMessage("(501) 777-9272", "+91" + Mobile, "Hi", null, "");
        }
    }
}