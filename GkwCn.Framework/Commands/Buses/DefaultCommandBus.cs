using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands.Buses
{
    public class DefaultCommandBus:ICommandBus
    {
        private ICommandExecuterRegistry _handlerRegistry;

        public static ICommandBus Instance { get; set; }

        public DefaultCommandBus(ICommandExecuterRegistry eventHandlerRegistry)
        {
            Require.NotNull(eventHandlerRegistry, "eventHandlerRegistry");
            _handlerRegistry = eventHandlerRegistry;
        }

        public void SendCommand<TEvent>(TEvent evnt) where TEvent : ICommand
        {
            Require.NotNull(evnt, "evnt");

            var eventType = evnt.GetType();

            HandlerInvoker.Invoke(_handlerRegistry.FindHandlers(eventType), "Execute", evnt);
        }

        public TResult SendCommand<TEvent, TResult>(TEvent evnt)
            where TEvent : ICommand
            where TResult : class
        {
            Require.NotNull(evnt, "evnt");

            var eventType = evnt.GetType();

            return HandlerInvoker.InvokeReturnValue(_handlerRegistry.FindHandlers(eventType), "Execute", evnt) as TResult;
        }

        public bool RegisterHandler(Type handlerType)
        {
            Require.NotNull(handlerType, "handlerType");
            return _handlerRegistry.RegisterHandler(handlerType);
        }

        public void RegisterHandlers(IEnumerable<System.Reflection.Assembly> assembliesToScan)
        {
            Require.NotNull(assembliesToScan, "assembliesToScan");
            _handlerRegistry.RegisterHandlers(assembliesToScan);
        }

        public bool UnregisterHandler(Type handlerType)
        {
            Require.NotNull(handlerType, "handlerType");
            return _handlerRegistry.UnregisterHandler(handlerType);
        }

        public void UnregisterHandlers(Type eventType)
        {
            Require.NotNull(eventType, "eventType");
            _handlerRegistry.UnregisterHandlers(eventType);
        }

        public void UnregisterAllHandlers()
        {
            _handlerRegistry.UnregisterAllHandlers();
        }
    }
}
