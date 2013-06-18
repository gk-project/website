using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Framework.Events
{
    public interface IEvent
    {
        DateTime UtcTimestamp { get; }
    }
}
