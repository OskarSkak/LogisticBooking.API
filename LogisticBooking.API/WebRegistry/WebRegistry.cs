using System;
using LogisticBooking.Domain.Registry;
using LogisticBooking.Events.Registry;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Infrastructure.MessagingInfrastructure.Mediators;
using LogisticBooking.Infrastructure.MessagingInfrastructure.Registry;
using LogisticBooking.Persistence.Registry;
using LogisticBooking.Queries.Registry;


namespace LogisticBooking.API.WebRegistry
{
    public class WebRegistry : StructureMap.Registry
    {
        public WebRegistry()
        {
            IncludeRegistry<MessagingInfrastructureRegistry>();
            IncludeRegistry<CommandRegistry>();
            IncludeRegistry<QueryRegistry>();
            IncludeRegistry<EventRegistry>();
            IncludeRegistry<PersistenceRegistry>();
        }
    }
}