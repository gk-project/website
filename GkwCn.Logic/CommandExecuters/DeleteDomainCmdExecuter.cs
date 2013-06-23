using GkwCn.Domains;
using GkwCn.Domains.Business;
using GkwCn.Domains.News;
using GkwCn.Domains.Product;
using GkwCn.Framework.Commands;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.CommandExecuters
{
    public class DeleteDomainCmdExecuter : AbstractCommandExecuter<DeleteDomainCmd>
    {
        public override object Execute(DeleteDomainCmd cmd)
        {
            BaseDomainObject domain = null;
            switch (cmd.Type)
            {
                case SiteType.NEWS:
                    domain = UnitOfWork.Get<News>(cmd.Id);
                    break;
                case SiteType.COMPANY:
                    domain = UnitOfWork.Get<Company>(cmd.Id);
                    break;
                case SiteType.PRODUCT:
                    domain = UnitOfWork.Get<Product>(cmd.Id);
                    break;
                case SiteType.COOPERATE:
                    domain = UnitOfWork.Get<Cooperate>(cmd.Id);
                    break;
                case SiteType.TRADE:
                    domain = UnitOfWork.Get<Trade>(cmd.Id);
                    break;
            }
            domain.Delete();
            UnitOfWork.Commit();
            return domain;
        }
    }
}
