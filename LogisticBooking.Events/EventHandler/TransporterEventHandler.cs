using System;
using System.Data.SqlClient;
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
        
        
        public async Task HandleAsync(TransporterCreatedEvent evt, CancellationToken ct)
        {
            var HashKey = new RegistrationKey();
            var guid = Guid.NewGuid();
            HashKey.email = "test123@test.dk";

            var salt = BCryptHelper.GenerateSalt();
            
            var enc = BCrypt.Net.BCrypt.HashPassword(guid.ToString() , salt);
            HashKey.id = enc;
            var key = "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";
            var client = new SendGridClient(key);
            var from = new EmailAddress("test@test.dk");
            var subject = "Activation link";
            var to = new EmailAddress("caspha17@gmail.com");
            var plaintext = "easy peasy";
            var htmlContent = "https://localhost:5025/CreateUser/"+ guid;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plaintext, htmlContent);
            var response = await client.SendEmailAsync(msg);
            Console.WriteLine(response);

           var result = await _registrationRepository.InsertAsync(HashKey);
           Console.WriteLine(result);



        }
    }
}