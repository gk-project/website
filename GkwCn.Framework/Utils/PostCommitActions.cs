﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GkwCn.Framework.Utils;
using GkwCn.Framework.Data;
using System.Threading;

namespace GkwCn.Framework.Utils
{
    public static class PostCommitActions
    {
        static ThreadLocal<List<Action>> _actions = new ThreadLocal<List<Action>>(() => new List<Action>());

        public static void Enqueue(Action action)
        {
            Require.NotNull(action, "action");
            _actions.Value.Add(action);
        }

        public static int Count()
        {
            return _actions.Value.Count;
        }

        public static IEnumerable<Action> GetQueuedActions()
        {
            return _actions.Value;
        }

        public static void Clear()
        {
            _actions.Value.Clear();
        }
    }
}
