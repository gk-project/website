using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains
{
    public enum DomainStatue
    {
        Delete = 0,
        Effective,
        Invalid
    }

    public enum NewsType
    {
        //业界动态=0,
        //新品资讯=1,
        //专题报道=2,
        //人物专访=3,
        //视频新闻=4
        行业动态 = 0,
        本站动态 = 1,
        专题报道 = 2,
        业界动态 = 3,
        人物专访 = 4,
        新品速递 = 5,
        商务新闻 = 6,
        参展预告 = 7,
        企业公告 = 8,
        gongkong视点 = 9,
        培训动态 = 10,
        最新动态 = 11,
        招标公告 = 12,
        宏观政策 = 13,
        板块动态 = 14
    }
}
