using GkwCn.Framework.Commands;
using GkwCn.Models.Commands;
using GkwCn.Models.Commands.Common;
using GkwCn.Models.Domain;
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
            var domain = new BuildStaticPage() { Domain = cmd.Domain, Id = cmd.Id, Type = cmd.Type, BuildType = cmd.BuildType };
            if (domain.BuildType == BuildType.REPLACE || domain.BuildType==BuildType.CREATE && !domain.IsExistStaticFile())
            {
                if (domain.IsExistDirectory() && BuildFile(domain))
                {
                    return domain.GetNewUrl();
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return domain.GetNewUrl();
            }
        }

        private bool BuildFile(BuildStaticPage domain)
        {
            var isSucc = false;
            var url = string.Format("http://{0}/{1}/details/{2}?t={3}", domain.Domain, domain.Type.ToString(), domain.Id, 0);
            var bytes = new byte[0];
            var encoding = string.Empty;
            try
            {
                var request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Method = "GET";
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    encoding = response.ContentEncoding;
                    if (encoding.IsNullOrEmpty())
                        encoding = "utf-8";
                    using (var stream =new StreamReader(response.GetResponseStream(),Encoding.GetEncoding(encoding)))
                    {
                        if (response.StatusCode == HttpStatusCode.OK && response.ContentLength > 0)
                        {
                            var html = stream.ReadToEnd();
                            File.WriteAllText(domain.GetFilePath(), html);
                            isSucc = true;
                        }
                    }
                }
            }
            catch
            {
                isSucc = false;
            }
            return isSucc;
        }
    }
}
