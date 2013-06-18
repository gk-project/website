using GkwCn.Domains;
using GkwCn.Framework.Commands;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.CommandExecuters
{
    public class CreateCompanyCmdExecuter : AbstractCommandExecuter<CreateCompanyCmd>
    {
        public override object Execute(CreateCompanyCmd cmd)
        {
            var domain = new Company();
            domain.InitDomain(cmd);
            UnitOfWork.Save(domain);
            UnitOfWork.Commit();
            return domain;
        }
    }
}
