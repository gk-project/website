using GkwCn.Domains;
using GkwCn.Models.Commands;
using GkwCn.Models.Events;
using GkwCn.Framework.Commands;
using GkwCn.Framework.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GkwCn.Logic.CommandExecuters
{
    public class ChangePasswordCmdExecuter : AbstractCommandExecuter<ChangePasswordCmd>
    {
        public override object Execute(ChangePasswordCmd cmd)
        {
            using (var tran = UnitOfWork.OpenUnitOfWorkScope())
            {
                var db = tran.UnitOfWork;
                var old = db.Get<RegUser>(cmd.Id);
                DomainEvent.Apply(new ChangedPasswordEvent(cmd.Id, DateTime.Now));
                if (old.ChangePassword(cmd.OldPassword, cmd.Password, cmd.RePassword))
                    db.Commit();
                return old;
            }
        }
    }
}