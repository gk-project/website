using GkwCn.Domains;
using GkwCn.Domains.Business;
using GkwCn.Domains.News;
using GkwCn.Domains.Product;
using GkwCn.Framework.QueryServices;
using GkwCn.Framework.Utils;
using GkwCn.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.QueryService
{
    public class TagQueryService : AbstractQueryService
    {
        public TagListViewModel GetListByKeyword(string keyword, TagType type, BasePager page)
        {
            IEnumerable<Tag> tags = null;
            switch (type)
            {
                case TagType.新闻资讯:
                    tags = GetList<News>(o => o.Keyword.Contains(keyword), os => os.OrderByDescending(o => o.PublishTime), page).Select(o => new Tag { Id = o.Id, Title = o.Title, PublishTime = o.PublishTime, HitCount = o.Hit });
                    break;
                case TagType.企业厂商:
                    tags = GetList<Company>(o => o.Keyword.Contains(keyword), os => os.OrderByDescending(o => o.CreateTime), page).Select(o => new Tag { Id = o.Id, Title = o.Name, PublishTime = o.CreateTime, HitCount = o.Hit });
                    break;
                case TagType.产品选型:
                    tags = GetList<Product>(o => o.Keyword.Contains(keyword), os => os.OrderByDescending(o => o.PublishTime), page).Select(o => new Tag { Id = o.Id, Title = o.Name, PublishTime = o.PublishTime, HitCount = o.Hit });
                    break;
                case TagType.商务合作:
                    tags = GetList<Cooperate>(o => o.Keyword.Contains(keyword), os => os.OrderByDescending(o => o.CreateTime), page).Select(o => new Tag { Id = o.Id, Title = o.Title, PublishTime = o.CreateTime, HitCount = o.Hit });
                    break;
            }
            return new TagListViewModel() { Keyword = keyword, ListValue = tags, Page = page, Type = type };
        }
    }
}
