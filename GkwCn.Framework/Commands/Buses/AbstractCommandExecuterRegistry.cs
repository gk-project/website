using GkwCn.Framework.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Commands.Buses
{
    public abstract class AbstractCommandExecuterRegistry:ICommandExecuterRegistry
    {
        // Key: Event Type, Value: Handler Type
        private Dictionary<Type, Type> _handlerTypes = new Dictionary<Type, Type>();
        private readonly object _lock = new object();

        public object FindHandlers(Type eventType)
        {
            Require.NotNull(eventType, "eventType");

            if (_handlerTypes.ContainsKey(eventType))
            {
                return Activator.CreateInstance(_handlerTypes[eventType]);
            }
            return null;
        }

        public bool RegisterHandler(Type handlerType)
        {
            Require.NotNull(handlerType, "handlerType");

            lock (_lock)
            {
                return NonThreadSafeRegisterHandler(handlerType);
            }
        }

        private bool NonThreadSafeRegisterHandler(Type handlerType)
        {
            if (!handlerType.IsClass || handlerType.IsAbstract || handlerType.IsGenericType) return false;

            var eventType = ExtractEventType(handlerType);

            if (eventType != null)
            {
                if (!_handlerTypes.ContainsKey(eventType))
                {
                    _handlerTypes[eventType] = handlerType;
                }

                return true;
            }

            return false;
        }

        public void RegisterHandlers(IEnumerable<Assembly> assembliesToScan)
        {
            Require.NotNull(assembliesToScan, "assembliesToScan");

            lock (_lock)
            {
                foreach (var assembly in assembliesToScan)
                {
                    foreach (var type in assembly.GetTypes())
                    {
                        NonThreadSafeRegisterHandler(type);
                    }
                }
            }
        }

        public bool UnregisterHandler(Type handlerType)
        {
            Require.NotNull(handlerType, "handlerType");

            lock (_lock)
            {
                var item = _handlerTypes.First(o => o.Value == handlerType);
                if (item.Key != null)
                    _handlerTypes.Remove(item.Key);
            }

            return false;
        }

        public void UnregisterHandlers(Type eventType)
        {
            Require.NotNull(eventType, "eventType");

            if (!_handlerTypes.ContainsKey(eventType)) return;

            lock (_lock)
            {
                if (_handlerTypes.ContainsKey(eventType))
                {
                    _handlerTypes.Remove(eventType);
                }
            }
        }

        public void UnregisterAllHandlers()
        {
            lock (_lock)
            {
                _handlerTypes.Clear();
            }
        }

        protected abstract Type ExtractEventType(Type handlerType);
    }
}
