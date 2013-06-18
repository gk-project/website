using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands
{
    public class DeleteDomainCmd:ICommand
    {
        public int Id { get; set; }

        public SiteType Type { get; set; }
    }
}
