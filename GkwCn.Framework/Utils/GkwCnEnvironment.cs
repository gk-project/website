using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using GkwCn.Framework.Data;
using GkwCn.Framework.Events;
using GkwCn.Framework.Events.Buses;
using GkwCn.Framework.Utils;
using GkwCn.Framework.Commands.Buses;

namespace GkwCn.Framework.Utils
{
    public class GkwCnEnvironment
    {
        public static readonly GkwCnEnvironment Instance = new GkwCnEnvironment();

        public IEventBus ImmediateEventBus { get; set; }

        public IEventBus PostCommitEventBus { get; set; }

        public ICommandBus CommandBus { get; set; }

        public Func<IDbContext> UnitOfWorkFactory { get; set; }

        private GkwCnEnvironment()
        {
            ImmediateEventBus = new DefaultEventBus(new ImmediateEventHandlerRegistry());
            PostCommitEventBus = new DefaultEventBus(new PostCommitEventHandlerRegistry());
            CommandBus = new DefaultCommandBus(new CommandExecuterRegistry());
            DefaultCommandBus.Instance = CommandBus;
        }

        public static void Configure(Action<GkwCnEnvironment> action)
        {
            Require.NotNull(action, "action");
            action(Instance);
        }

        public GkwCnEnvironment RegisterHandlers(params Assembly[] assembliesToScan)
        {
            return RegisterEventHandlers(assembliesToScan as IEnumerable<Assembly>);
        }

        public GkwCnEnvironment RegisterEventHandlers(IEnumerable<Assembly> assembliesToScan)
        {
            Require.NotNull(assembliesToScan, "assembliesToScan");

            var immediateEventBus = ImmediateEventBus;
            var postCommitEventBus = PostCommitEventBus;

            if (immediateEventBus == null)
                throw new InvalidOperationException("Please register immediate event bus to the GkwCnEnvironment first.");

            if (postCommitEventBus == null)
                throw new InvalidOperationException("Please register post commit event bus to the GkwCnEnvironment first.");

            if (CommandBus != null)
                CommandBus.RegisterHandlers(assembliesToScan);
            else
                throw new InvalidOperationException("Please register Command Bus to the GkwCnEnvironment first.");

            immediateEventBus.RegisterHandlers(assembliesToScan);
            postCommitEventBus.RegisterHandlers(assembliesToScan);
            

            return this;
        }

        public GkwCnEnvironment RegisterUnitOfWorkFactory(Func<IDbContext> factory)
        {
            Require.NotNull(factory, "factory");
            UnitOfWorkFactory = factory;
            return this;
        }
    }
}
