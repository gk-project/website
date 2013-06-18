using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.ViewModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int HitCount { get; set; }
        public DateTime PublishTime { get; set; }
    }

    public enum TagType
    {
        新闻资讯 = 0,
        企业厂商 = 1,
        产品选型 = 2,
        商务合作 = 3
    }

    public class TagListViewModel:BaseListViewModel<Tag>
    {
        public string Keyword { get; set; }

        public TagType Type { get; set; }
    }
}
