using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GkwCn.Framework.Events
{
    public interface IImmediatelyEventHandler<in TEvent>
        where TEvent : IEvent
    {
        void Handle(TEvent evnt);
    }
}
