using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GkwCn.Framework.Events.Buses
{
    public class PostCommitEventHandlerRegistry : AbstractEventHandlerRegistry
    {
        protected override Type ExtractEventType(Type handlerType)
        {
            return HandlerFinderUtil.TryFindEventTypeOfImplementedHandlerInterface(handlerType, typeof(IPostCommitEventHandler<>));
        }
    }
}
