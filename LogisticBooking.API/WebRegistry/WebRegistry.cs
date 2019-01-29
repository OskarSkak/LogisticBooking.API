using System;
using LogisticBooking.Infrastructure.MessagingInfrastructure.Registry;


namespace LogisticBooking.API.WebRegistry
{
    public class WebRegistry : StructureMap.Registry
    {
        public WebRegistry()
        {
            IncludeRegistry<MessagingInfrastructureRegistry>();         
        }
    }
}