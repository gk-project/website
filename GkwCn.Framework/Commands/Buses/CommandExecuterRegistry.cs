using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands.Buses
{
    public class CommandExecuterRegistry : AbstractCommandExecuterRegistry
    {
        protected override Type ExtractEventType(Type handlerType)
        {
            return HandlerFinderUtil.TryFindEventTypeOfImplementedHandlerInterface(handlerType, typeof(ICommandExecuter<>));
        }
    }
}
