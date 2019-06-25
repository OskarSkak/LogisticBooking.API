
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using LogisticBooking.Documents.Resources;
using LogisticBooking.Events.Events;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using SimpleSoft.Mediator;


namespace LogisticBooking.Events.EventHandler
{
    public class TransporterEventHandler : IEventHandler<TransporterCreatedEvent> , IEventHandler<TransporterDeletedEvent>
    {
        private readonly IOptions<IdentityServerConfiguration> _serviceSettings;


        public TransporterEventHandler(IOptions<IdentityServerConfiguration> serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }
        
        /***
         * This event is raised when a Transporter is created.
         * The send an email with a activation link to the transporter
         */
        public async Task HandleAsync(TransporterCreatedEvent evt, CancellationToken ct)
        {
            
            // >Options for sendgrid
            var key = "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";
            var client = new SendGridClient(key);
            var from = new EmailAddress("AutoMail@LogisticSolutions.dk");
            var subject = "Activation link to Booking Planner";
            var to = new EmailAddress(evt.Email);
            var plaintext = "<h2>Welcome</h2><span>Agri-Norcold has invited you to try out the new platform for booking</span> </br><span>First you need to go in and create a new password for the account that was created for you <a href=" +
                            "";

            var plaintext1 = " " + " > here</a> "+ "</span></br> If you have any questions, please contact us at <a href=" +
                             "https://logistictechnologies.eu/" + " >Logistic Technologies</a></br> ";
            var htmlContent = plaintext + _serviceSettings.Value.IdentityServerUrl + "/User/" + evt.Id + plaintext1;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
            //#TODO check for hvilken exception den kalder hvis emailem er forkert

        }

        public Task HandleAsync(TransporterDeletedEvent evt, CancellationToken ct)
        {
            // Delete transporter identityserver;
            HttpClient client = new HttpClient();

            var result = client.PostAsync("https://localhost:5025/user/" +evt.Id +  "" , null);
            return null;
        }
    }
}