using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GkwCn.Framework.Utils;
using System.Reflection;

namespace GkwCn.Framework.Events.Buses
{
    public class ImmediateEventHandlerRegistry : AbstractEventHandlerRegistry
    {
        protected override Type ExtractEventType(Type handlerType)
        {
            return HandlerFinderUtil.TryFindEventTypeOfImplementedHandlerInterface(handlerType, typeof(IImmediatelyEventHandler<>));
        }
    }
}
