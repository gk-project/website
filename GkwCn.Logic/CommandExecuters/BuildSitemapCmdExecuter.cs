using GkwCn.Domains;
using GkwCn.Domains.Business;
using GkwCn.Domains.News;
using GkwCn.Domains.Product;
using GkwCn.Framework.Commands;
using GkwCn.Models.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Logic.CommandExecuters
{
    public class BuildSitemapCmdExecuter : AbstractCommandExecuter<BuildSitemapCmd>
    {
        private const string domainUrl = "http://www.gkwcn.com";
        private const string defaultFileName = "sitemap";
        private const int MAXCOUNT = 50000;
        private const int size = 5000;
        private static string _basePath = AppDomain.CurrentDomain.BaseDirectory;
        private int buildCount = 0;
        private static object LockType = new object();
        public int GetLastFileIndex(SiteType type)
        {
            var findex = Directory.GetFiles(_basePath).Select(o => o.Replace(_basePath, "").Replace(type.ToString().ToLower(), "").Replace(".txt", "").Replace("-", "").Replace(defaultFileName, "").ToInt()).Max();
            if (buildCount + size >= MAXCOUNT)
            {
                buildCount = 0;
                findex++;
            }
            return findex;
        }

        public void BuildSitemap(SiteType type, IEnumerable<string> ids)
        {
            lock (LockType)
            {
                var filename = Path.Combine(_basePath, string.Format("{0}-{1}-{2}.{3}", defaultFileName, type.ToString().ToLower(), GetLastFileIndex(type), "txt"));
                if (!File.Exists(filename))
                    File.Create(filename).Close();
                File.AppendAllLines(filename, ids, Encoding.UTF8);
            }
        }

        public void DeleteSitemap(SiteType type)
        {
            var filename = string.Format("{0}-{1}-", defaultFileName, type.ToString().ToLower());
            var files = Directory.GetFiles(_basePath).Select(o => o.Replace(_basePath, ""));
            foreach (var path in files)
            {
                if (path.IndexOf(filename) != -1)
                {
                    File.Delete(Path.Combine(_basePath, path));
                }
            }
        }

        public override object Execute(BuildSitemapCmd cmd)
        {
            DeleteSitemap(cmd.Type);
            var totalCount = 0;
            var db = UnitOfWork;
            if (cmd.Type == SiteType.NEWS)
                totalCount = db.Query<News>().Where(o => o.Statue == Domains.DomainStatue.Effective).Count();
            else if (cmd.Type == SiteType.COMPANY)
                totalCount = db.Query<Company>().Where(o => o.Statue == Domains.DomainStatue.Effective).Count();
            else if (cmd.Type == SiteType.PRODUCT)
                totalCount = db.Query<Product>().Where(o => o.Statue == Domains.DomainStatue.Effective).Count();
            else if (cmd.Type == SiteType.COOPERATE)
                totalCount = db.Query<Cooperate>().Where(o => o.Statue == Domains.DomainStatue.Effective).Count();
            else if (cmd.Type == SiteType.TRADE)
                totalCount = db.Query<Trade>().Where(o => o.Statue == Domains.DomainStatue.Effective).Count();
            var index = 0;
            var errorCount = 0;
            do
            {
                try
                {
                    IEnumerable<int> ids;
                    if (cmd.Type == SiteType.NEWS)
                        ids = db.Query<News>().Where(o => o.Statue == Domains.DomainStatue.Effective).OrderBy(o => o.Id).Skip((Math.Max(0, index - 1)) * size).Take(size).Select(o => o.Id).ToList();
                    else if (cmd.Type == SiteType.COMPANY)
                        ids = db.Query<Company>().Where(o => o.Statue == Domains.DomainStatue.Effective).OrderBy(o => o.Id).Skip((Math.Max(0, index - 1)) * size).Take(size).Select(o => o.Id).ToList();
                    else if (cmd.Type == SiteType.PRODUCT)
                        ids = db.Query<Product>().Where(o => o.Statue == Domains.DomainStatue.Effective).OrderBy(o => o.Id).Skip((Math.Max(0, index - 1)) * size).Take(size).Select(o => o.Id).ToList();
                    else if (cmd.Type == SiteType.COOPERATE)
                        ids = db.Query<Cooperate>().Where(o => o.Statue == Domains.DomainStatue.Effective).OrderBy(o => o.Id).Skip((Math.Max(0, index - 1)) * size).Take(size).Select(o => o.Id).ToList();
                    else if (cmd.Type == SiteType.TRADE)
                        ids = db.Query<Trade>().Where(o => o.Statue == Domains.DomainStatue.Effective).OrderBy(o => o.Id).Skip((Math.Max(0, index - 1)) * size).Take(size).Select(o => o.Id).ToList();
                    else
                        ids = new int[] { };
                    var urls = ids.Select(id => string.Format("{0}/{1}/{2}/{3}", domainUrl, cmd.Type.ToString().ToLower(), "details", id));
                    BuildSitemap(cmd.Type, urls);
                    buildCount += size;
                    index++;
                    errorCount = 0;
                }
                catch (Exception ex)
                {
                    errorCount++;
                    if (errorCount > 3)
                    {
                        cmd.Message = "网站地图生成失败!" + ex.Message;
                        break;
                    }
                }
            } while (index * size < totalCount);
            index = 0;
            buildCount = 0;
            cmd.Message = "网站地图生成成功";
            return cmd;
        }
    }
}
