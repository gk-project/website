using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands.Buses
{
    public interface ICommandBus
    {
        void SendCommand<TEvent>(TEvent evnt) where TEvent : ICommand;

        TResult SendCommand<TEvent, TResult>(TEvent evnt)
            where TEvent : ICommand
            where TResult : class;

        bool RegisterHandler(Type handlerType);

        void RegisterHandlers(IEnumerable<Assembly> assembliesToScan);

        bool UnregisterHandler(Type handlerType);

        void UnregisterHandlers(Type eventType);

        void UnregisterAllHandlers();
    }
}
