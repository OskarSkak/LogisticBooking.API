using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogisticBooking.Queries.Queries
{
    public class GetTransporterById : Query<Transporter>
    {
        public Guid Id { get; set; }

        public GetTransporterById(Guid id)
        {
            Id = id;
        }
    }
}
