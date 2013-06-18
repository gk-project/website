using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GkwCn.Framework.Utils
{
    static class HandlerFinderUtil
    {
        public static Type TryFindEventTypeOfImplementedHandlerInterface(Type type, Type handlerInterfaceOpenGenericType)
        {
            foreach (var inter in type.GetInterfaces())
            {
                if (inter.IsGenericType)
                {
                    var def = inter.GetGenericTypeDefinition();
                    var eventType = inter.GetGenericArguments().FirstOrDefault();

                    if (def == handlerInterfaceOpenGenericType)
                    {
                        return eventType;
                    }
                }
            }

            return null;
        }
    }
}
