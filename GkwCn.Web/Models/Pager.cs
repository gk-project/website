using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GkwCn.Web.Models
{
    public class Pager : BasePager
    {
        public Pager()
        {
            FirstPagerSplitHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//首页代码
            LastPagerSplitHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//尾页代码
            PrevPagerSplitHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//上一页代码
            NextPagerSplitHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//下一页代码
            PrevGroupHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//上一组代码(就是...)
            NextGroupHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//下一组代码(就是...)
            UnEnablePagerSplitHtml = " <li class=\"disabled\"><a>{Text}</a></li> ";//不可点击状态
            CurrentPagerSplitHtml = " <li class=\"active\"><a>{Text}</a></li> ";//当前页码
            PagerSplitHtml = " <li><a href=\"{Url}\">{Text}</a></li> ";//普通分页代码
            PagerStatueHtml = "<li><a>总条数：{TotalRecord} | 当前第{Index}/{TotalPages}页</a></li>";//分页信息明细

            Size = 20;
            PagerBoxElType = "ul";
            IsShowSwipe = false;
            IsShowNextGroupButton = false;
            IsShowPrevGroupButton = false;
        }
    }
}