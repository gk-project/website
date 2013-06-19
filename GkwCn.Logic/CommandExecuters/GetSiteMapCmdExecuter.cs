using GkwCn.Framework.Commands;
using GkwCn.Models.Commands.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.CommandExecuters
{
    public class GetSiteMapCmdExecuter : AbstractCommandExecuter<GetSiteMapCmd>
    {
        private const string domainUrl = "http://www.gkwcn.com";
        private const string defaultFileName = "sitemap";
        private static string _basePath = AppDomain.CurrentDomain.BaseDirectory;

        public IEnumerable<string> GetFiles()
        {
            return Directory.GetFiles(_basePath).Select(o => string.Format("{0}/{1}", domainUrl, o.Replace(_basePath, ""))).Where(o => o.Contains(defaultFileName)).ToList();
        }

        public override object Execute(GetSiteMapCmd cmd)
        {
            cmd.MapFiles = GetFiles();
            return cmd;
        }
    }
}
