using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using GkwCn.Framework.Data;
using GkwCn.Framework.Events;
using GkwCn.Framework.Events.Buses;
using System.Threading;
using GkwCn.Framework.Utils;

namespace GkwCn.Framework.Events
{
    public static class DomainEvent
    {
        static ThreadLocal<UncommittedEventStream> _uncommittedEvents = new ThreadLocal<UncommittedEventStream>(() => new UncommittedEventStream());

        public static void Apply<TEvent>(TEvent evnt)
            where TEvent : IEvent
        {
            Require.NotNull(evnt, "evnt");

            var bus = GkwCnEnvironment.Instance.ImmediateEventBus;

            if (bus == null)
                throw new InvalidOperationException("Immediate event bus is not registered to the TaroEnvironment.");

            bus.Publish<TEvent>(evnt);

            _uncommittedEvents.Value.Append(evnt);
        }

        public static UncommittedEventStream GetThreadStaticPendingEvents()
        {
            return _uncommittedEvents.Value;
        }

        public static void ClearAllThreadStaticPendingEvents()
        {
            _uncommittedEvents.Value.Clear();
        }
    }
}
