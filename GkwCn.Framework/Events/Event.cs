using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Events
{
    [Serializable, DataContract]
    public abstract class Event : IEvent
    {
        [DataMember]
        public DateTime UtcTimestamp { get; protected set; }

        protected Event()
            : this(DateTime.UtcNow)
        {
        }

        protected Event(DateTime utcTimestamp)
        {
            UtcTimestamp = utcTimestamp;
        }
    }
}
