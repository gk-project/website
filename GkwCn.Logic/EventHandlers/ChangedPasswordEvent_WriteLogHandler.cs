using GkwCn.Domains;
using GkwCn.Models.Events;
using GkwCn.Framework.Data;
using GkwCn.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.EventHandlers
{
    public class ChangedPasswordEvent_WriteLogHandler : AbstractImmediatelyEventHandler<ChangedPasswordEvent>
    {

        public override void Handle(ChangedPasswordEvent evnt)
        {
            UnitOfWork.Save<RegUserLog>(new RegUserLog(evnt.Id, "", UserActionEnum.ChangePassword, evnt.CreateTime));
            UnitOfWork.Dispose();
        }
    }
}
