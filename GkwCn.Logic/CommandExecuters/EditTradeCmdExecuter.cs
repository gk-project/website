using GkwCn.Domains.Business;
using GkwCn.Framework.Commands;
using GkwCn.Models.Commands.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.CommandExecuters
{
    public class EditTradeCmdExecuter : AbstractCommandExecuter<EditTradeCmd>
    {
        public override object Execute(EditTradeCmd cmd)
        {
            var domain = UnitOfWork.Get<Trade>(cmd.Id);
            domain.InitDomain(cmd);
            UnitOfWork.Commit();
            return domain;
        }
    }
}
