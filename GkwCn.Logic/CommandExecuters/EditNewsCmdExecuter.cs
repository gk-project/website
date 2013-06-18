using GkwCn.Domains.News;
using GkwCn.Framework.Commands;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.CommandExecuters
{
    public class EditNewsCmdExecuter : AbstractCommandExecuter<EditNewsCmd>
    {
        public override object Execute(EditNewsCmd cmd)
        {
            var domain = UnitOfWork.Get<News>(cmd.Id);
            domain.InitDomain(cmd);
            UnitOfWork.Commit();
            return domain;
        }
    }
}
