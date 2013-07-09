using GkwCn.Models.Commands;
using GkwCn.Models.Commands.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Domain
{
    public class BuildStaticPage
    {
        public int Id { get; set; }

        public SiteType Type { get; set; }

        public string Domain { get; set; }

        public BuildType BuildType { get; set; }

        public string GetNewUrl()
        {
            return string.Format("http://{0}/{1}/{2}.html", Domain, Type.ToString(), Id).ToLower();
        }

        public bool IsExistStaticFile()
        {
            return File.Exists(GetFilePath());
        }

        public string GetFilePath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}/{1}.html", Type.ToString(), Id));
        }

        public bool IsExistDirectory()
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Type.ToString());
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return true;
        }
    }
}
