using SendGrid.Helpers.Mail;

namespace LogisticBooking.Events.Tools.EmailTools
{
    public interface IEmailHandler
    {
        void SendEmail(SendGridMessage message);
    }
}