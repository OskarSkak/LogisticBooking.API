using System.Diagnostics;
using SimpleSoft.Mediator;

namespace LogisticBooking.Events.Registry
{
    public class EventRegistry : StructureMap.Registry
    {
        public EventRegistry()
        {
            Scan(scanner =>
            {
                scanner.AssemblyContainingType<EventRegistry>();
                
                
                
                scanner.ConnectImplementationsToTypesClosing(typeof(IEventHandler<>));
                
                scanner.SingleImplementationsOfInterface();
            });
        }
    }
}