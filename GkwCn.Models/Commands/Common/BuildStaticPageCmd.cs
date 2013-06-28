using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands.Common
{

    public class BuildStaticPageCmd : ICommand
    {
        public BuildStaticPageCmd(string domain)
        {
            Domain = domain;
        }

        public string Domain { get; private set; }

        public int Id { get; set; }

        public SiteType Type { get; set; }
    }
}
