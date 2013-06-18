using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GkwCn.Framework.Events;
using GkwCn.Framework.Data;
using GkwCn.Domains;
using GkwCn.Models.Events;

namespace GkwCn.Logic.EventHandler
{
    public class RegisteredEvent_SendEmailHandler:AbstractPostCommitEventHandler<RegisteredEvent>
    {
        public override void Handle(RegisteredEvent evnt)
        {
            UnitOfWork.Save(new RegUserLog(evnt.Id, "", UserActionEnum.Register, DateTime.Now));
            UnitOfWork.Dispose();
        }
    }
}
