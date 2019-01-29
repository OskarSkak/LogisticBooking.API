using LogisticBooking.Domain.Registry;
using LogisticBooking.Infrastructure.MessagingContracts;
using LogisticBooking.Infrastructure.MessagingInfrastructure.Factory;
using LogisticBooking.Infrastructure.MessagingInfrastructure.Mediators;
using LogisticBooking.Persistence.Registry;
using SimpleSoft.Mediator;

namespace LogisticBooking.Infrastructure.MessagingInfrastructure.Registry
{
    public class MessagingInfrastructureRegistry : StructureMap.Registry
    {
        public MessagingInfrastructureRegistry()
        {
            For<IMediator>().Use<Mediator>();//https://github.com/jbogard/MediatR/blob/master/src/MediatR/Mediator.cs
            For<IMediatorFactory>().Use<StructureMapMediatorFactory>();

            For<ICommandRouter>().Use<MediatorCommandRouter>();
            For<IQueryRouter>().Use<MediatorQueryRouter>();


            IncludeRegistry<CommandRegistry>();
	        
            IncludeRegistry<PersistenceRegistry>();
        }
    }
}