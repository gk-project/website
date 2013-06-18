using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace GkwCn.Framework.Utils
{
    static class HandlerInvoker
    {
        public static void Invoke(object handler,string type, object evnt)
        {
            var method = handler.GetType().GetMethod(type, BindingFlags.Instance | BindingFlags.Public);
            method.Invoke(handler, new object[] { evnt });
        }

        public static object InvokeReturnValue(object handler, string type, object evnt)
        {
            var method = handler.GetType().GetMethod(type, BindingFlags.Instance | BindingFlags.Public);
            return method.Invoke(handler, new object[] { evnt });
        }
    }
}
