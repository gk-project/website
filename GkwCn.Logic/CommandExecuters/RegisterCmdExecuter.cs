using GkwCn.Domains;
using GkwCn.Models.Events;
using GkwCn.Models.Commands;
using GkwCn.Framework.Commands;
using GkwCn.Framework.Events;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace GkwCn.Logic.CommandExecuters
{
    public class RegisterCmdExecuter:AbstractCommandExecuter<RegisterCmd>
    {
        public override object Execute(RegisterCmd cmd)
        {
            var db = UnitOfWork;
            var regUser = db.NewObject<RegUser>();
            if (regUser.ValidationPassword(cmd.Password, cmd.RePassword))
            {
                regUser.LoginName = cmd.LoginName;
                regUser.Email = cmd.Email;
                regUser.CreateTime = DateTime.Now;
                regUser.ActionyUser();
                db.Save(regUser);
                db.Execute();
                DomainEvent.Apply(new RegisteredEvent(regUser.Id, regUser.LoginName, regUser.Email));
                db.Commit();
            }
            return regUser;
        }
    }
}