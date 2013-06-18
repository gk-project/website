using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands.Buses
{
    public interface ICommandExecuterRegistry
    {
        object FindHandlers(Type eventType);

        bool RegisterHandler(Type handlerType);

        void RegisterHandlers(IEnumerable<Assembly> assembliesToScan);

        bool UnregisterHandler(Type handlerType);

        void UnregisterHandlers(Type eventType);

        void UnregisterAllHandlers();
    }
}
