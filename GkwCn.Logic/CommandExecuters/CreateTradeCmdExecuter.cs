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
    public class CreateTradeCmdExecuter : AbstractCommandExecuter<CreateTradeCmd>
    {
        public override object Execute(CreateTradeCmd cmd)
        {
            var domain = new Trade();
            return domain;
        }
    }
}
