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
    public class CreateNewsCmdExecuter : AbstractCommandExecuter<CreateNewsCmd>
    {
        public override object Execute(CreateNewsCmd cmd)
        {
            var domain = new News();
            domain.InitDomain(cmd);
            UnitOfWork.Save(domain);
            UnitOfWork.Commit();
            return domain;
        }
    }
}
