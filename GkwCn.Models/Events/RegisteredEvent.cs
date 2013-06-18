using GkwCn.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Events
{
    public class RegisteredEvent : Event
    {
        public int Id { get; private set; }

        public string LoginName { get; private set; }

        public string Email { get; private set; }

        public RegisteredEvent(int id, string lname, string email)
        {
            Id = id;
            LoginName = lname;
            Email = email;
        }
    }
}
