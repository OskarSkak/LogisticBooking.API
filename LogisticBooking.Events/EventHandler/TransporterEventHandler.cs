using System;
using System.Data.SqlClient;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using DevOne.Security.Cryptography.BCrypt;
using LogisticBooking.Events.Events;
using LogisticBooking.Persistence.BaseRepository;
using LogisticBooking.Persistence.Models;
using LogisticBooking.Persistence.Repositories;
using SendGrid;
using SendGrid.Helpers.Mail;
using SimpleSoft.Mediator;
using IRegistrationRepository = LogisticBooking.Persistence.Repositories.IRegistrationRepository;

namespace LogisticBooking.Events.EventHandler
{
    public class TransporterEventHandler : IEventHandler<TransporterCreatedEvent>
    {
        private readonly IRegistrationRepository _registrationRepository;


        public TransporterEventHandler(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
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
            var plaintext = "Hi and welcome to Booking planner\n To activate you're account you have to visit the link attached in this email and create a passsword. \n If you have any issues please contact us  ";
            var htmlContent = plaintext +  "https://localhost:5025/CreateUser/"+ evt.Id;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, htmlContent);
            var response = await client.SendEmailAsync(msg);
            
            //#TODO check for hvilken exception den kalder hvis emailem er forkert

        }
    }
}