using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands.Common
{
    public class GetSiteMapCmd : ICommand
    {
        public IEnumerable<string> MapFiles { get; set; }
    }
}
