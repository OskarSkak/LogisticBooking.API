using System;
using SendGrid.Helpers.Mail;

namespace LogisticBooking.Events.Tools.EmailTools
{
    public class EmailHandler : IEmailHandler

    {
        public void SendEmail(SendGridMessage message)
        {
            if (message == null)
            {
                throw new Exception("Can't send empty email");
            }
            
            
        }
    }
}