using GkwCn.Framework.Commands;
using GkwCn.Models.Commands;
using GkwCn.Models.Commands.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace GkwCn.Logic.CommandExecuters
{
    public class BuildStaticPageCmdExecuter : AbstractCommandExecuter<BuildStaticPageCmd>
    {
        public override object Execute(BuildStaticPageCmd cmd)
        {
            if (IsExistDire(cmd.Type) && BuildFile(cmd))
            {
                return GetNewUrl(cmd);
            }
            else
            {
                return "";
            }
        }

        private bool BuildFile(BuildStaticPageCmd cmd)
        {
            var isSucc = false;
            var url = string.Format("{0}/{1}/details/{2}", cmd.Domain, cmd.Type.ToString(), cmd.Id);
            var request = (HttpWebRequest)WebRequest.Create(url);
            var bytes = new byte[0];
            var encoding = string.Empty;
            try
            {
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    bytes = new byte[response.ContentLength];
                    using (var stream = response.GetResponseStream())
                    {
                        stream.Read(bytes, 0, (int)response.ContentLength);
                    }
                    if (response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0)
                    {
                        isSucc = true;
                        encoding = response.ContentEncoding;
                    }
                }
                if (isSucc)
                {
                    var html = Encoding.GetEncoding(encoding).GetString(bytes);
                    File.WriteAllText(GetFilePath(cmd), html);
                    isSucc = true;
                }
            }
            catch
            {
                isSucc = false;
            }
            return isSucc;
        }

        private string GetNewUrl(BuildStaticPageCmd cmd)
        {
            return string.Format("{0}/{1}/{2}.html", cmd.Domain, cmd.Type.ToString(), cmd.Id).ToLower();
        }

        private bool IsExistStaticFile(BuildStaticPageCmd cmd)
        {
            return File.Exists(GetFilePath(cmd));
        }

        private string GetFilePath(BuildStaticPageCmd cmd)
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, string.Format("{0}/{1}.html", cmd.Type.ToString(), cmd.Id));
        }

        private bool IsExistDire(SiteType type)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, type.ToString());
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return true;
        }
    }
}
