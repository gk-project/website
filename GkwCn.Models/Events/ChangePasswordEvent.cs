using GkwCn.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Events
{
    public class ChangedPasswordEvent : Event
    {
        public int Id { get; private set; }

        public DateTime CreateTime { get; private set; }

        public ChangedPasswordEvent(int id, DateTime ctime)
        {
            this.Id = id;
            this.CreateTime = ctime;
        }
    }
}
