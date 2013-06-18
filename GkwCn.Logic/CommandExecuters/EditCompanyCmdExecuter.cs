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
    public class EditCompanyCmdExecuter : AbstractCommandExecuter<EditCompanyCmd>
    {
        public override object Execute(EditCompanyCmd cmd)
        {
            var domain = UnitOfWork.Get<Company>(cmd.Id);
            domain.InitDomain(cmd);
            UnitOfWork.Commit();
            return domain;
        }
    }
}
