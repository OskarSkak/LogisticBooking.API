using System;
using LogisticBooking.Persistence.Models;
using SimpleSoft.Mediator;

namespace LogisticBooking.Queries.Queries
{
    public class GetSupplierById : Query<Supplier>
    {
        public Guid id { get; set; }

        public GetSupplierById(Guid id)
        {
            this.id = id;
        }
    }
}