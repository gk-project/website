using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands
{
    public enum SiteType
    {
        NEWS = 0,
        COMPANY = 1,
        PRODUCT = 2,
        COOPERATE = 3,
        TRADE=4,
    }

    public class BuildSitemapCmd : ICommand
    {
        public SiteType Type { get; set; }

        public string Message { get; set; }
    }
}
