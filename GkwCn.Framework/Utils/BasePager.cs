using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GkwCn.Framework.Utils;

namespace GkwCn.Framework.Utils
{
    /// <summary>
    /// 分页对象
    /// </summary>
    public class BasePager
    {
        public enum PagerElementEnum
        {
            First = 0,
            Last = 1,
            Prev = 2,
            Next = 3,
            PrevGroup = 4,
            NextGroup = 5,
            Page = 6,
            UnPage = 7,
            LightPage = 8
        }

        /// <summary>
        /// 构造分页对象
        /// </summary>
        public BasePager()
        {
            Index = 1;
            Size = 50;
            PageCount = 10;
            GroupCount = 10;

            Action = "Index";
            PrevButtonText = "上一页";
            NextButtonText = "下一页";
            FirstButtonText = "首页";
            LastButtonText = "尾页";
            PrevGroupText = "...";
            NextGroupText = "...";
            SwipeButtonText = "转到";
            PageIndexName = "index";
            PageSizeName = "size";

            IsShowPrevButton = true;
            IsShowNextButton = true;
            IsShowFirst = true;
            IsShowLast = true;
            IsShowPrevGroupButton = true;
            IsShowNextGroupButton = true;
            IsShowSwipe = true;

            //UnEnableStyle = "sys_pageview_u_current";
            SwipePageButtonStyle = "swipe_page_button";
            SwipePageInputStyle = "swipe_page_input";
            DefaultPagerSplitStyle = "gk_pager_split";
            PagerLableStyle = "gk_page_label";
            PagerSplitStyle = "gk_page_split";
            PagerSwipeStyle = "gk_page_swipe";

            PagerStatueHtml = "总条数：{TotalRecord} | 当前第{Index}/{TotalPages}页";//分页信息明细
            FirstPagerSplitHtml = " <a href=\"{Url}\" class=\"first_pager\" >{Text}</a> ";//首页代码
            LastPagerSplitHtml = " <a href=\"{Url}\" class=\"last_pager\" >{Text}</a> ";//尾页代码
            PrevPagerSplitHtml = " <a href=\"{Url}\" class=\"prev_pager\" >{Text}</a> ";//上一页代码
            NextPagerSplitHtml = " <a href=\"{Url}\" class=\"next_pager\" >{Text}</a> ";//下一页代码
            PrevGroupHtml = " <a href=\"{Url}\" class=\"prev_group_pager\" >{Text}</a> ";//上一组代码(就是...)
            NextGroupHtml = " <a href=\"{Url}\" class=\"next_group_pager\" >{Text}</a> ";//下一组代码(就是...)
            UnEnablePagerSplitHtml = " <span class=\"disable_pager\" >{Text}</span> ";//不可点击状态
            CurrentPagerSplitHtml = " <span class=\"current_pager\" >{Text}</span> ";//当前页码
            PagerSplitHtml = " <a href=\"{Url}\" class=\"pager\" >{Text}</a> ";//普通分页代码
            LightPagerStyle = "light_pager";
        }

        //public string LightPagerJs
        //{
        //    get
        //    {
        //        return "<script type=\"text/javascript\">document.onload=function(){document.getElementById(\"" + PagerSplitStyle + "\")}</script>";
        //    }
        //}

        /// <summary>
        /// 构造分页对象
        /// </summary>
        /// <param name="totalPage">总页数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">页面显示的记录数</param>
        public BasePager(string action, string controller, string area, int totalPage, int pageIndex = 1, int pageSize = 10, Object paramObj = null)
            : this()
        {
            Index = pageIndex;
            TotalPage = totalPage;
            Size = pageSize;
            ParamObj = paramObj;
            if (!string.IsNullOrEmpty(action))
                Action = action;
            if (!string.IsNullOrEmpty(controller))
                Controller = controller;
            if (!string.IsNullOrEmpty(area))
                Area = area;
        }

        /// <summary>
        /// 默认的分页样式名称
        /// </summary>
        public string DefaultPagerSplitStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 分页Url上的附加参数
        /// </summary>
        public Object ParamObj
        {
            get;
            set;
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// 每页显示的记录数
        /// </summary>
        public int Size
        {
            get;
            set;
        }

        private int _totalPage = -1;
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPage
        {
            get
            {
                if (_totalPage <= 1)
                {
                    if (TotalCount % Size == 0)
                        _totalPage = TotalCount / Size;
                    else
                        _totalPage = TotalCount / Size + 1;
                    if (_totalPage < 1)
                        _totalPage = 1;
                }
                return _totalPage;
            }
            set
            {
                _totalPage = value;
            }
        }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalCount
        {
            get;
            set;
        }

        /// <summary>
        /// 分页控件显示的页码数量
        /// </summary>
        public int PageCount
        {
            get;
            set;
        }

        /// <summary>
        /// 下一组按钮的翻页数量
        /// </summary>
        public int GroupCount
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示上一页按钮
        /// </summary>
        public bool IsShowPrevButton
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示下一页按钮
        /// </summary>
        public bool IsShowNextButton
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示首页按钮
        /// </summary>
        public bool IsShowFirst
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示尾页按钮
        /// </summary>
        public bool IsShowLast
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示上一组按钮
        /// </summary>
        public bool IsShowPrevGroupButton
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示下一组按钮
        /// </summary>
        public bool IsShowNextGroupButton
        {
            get;
            set;
        }


        /// <summary>
        /// 是否为可点击的分码(是否给页码增加<span></span>标记)
        /// </summary>
        private bool IsUnEnablePager
        {
            get;
            set;
        }

        /// <summary>
        /// 是否显示跳转功能
        /// </summary>
        public bool IsShowSwipe
        {
            get;
            set;
        }

        /// <summary>
        /// 动作名称
        /// </summary>
        public string Action
        {
            get;
            set;
        }

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Controller
        {
            get;
            set;
        }

        /// <summary>
        /// 区域名称
        /// </summary>
        public string Area
        {
            get;
            set;
        }

        ///// <summary>
        ///// 页码使用的Html元素
        ///// </summary>
        //public string LinkHtmlElement
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 上一页按钮名称
        /// </summary>
        public string PrevButtonText
        {
            get;
            set;
        }

        /// <summary>
        /// 下一页按钮名称
        /// </summary>
        public string NextButtonText
        {
            get;
            set;
        }

        /// <summary>
        /// 首页按钮显示名称
        /// </summary>
        public string FirstButtonText
        {
            get;
            set;
        }

        /// <summary>
        /// 尾页按钮显示名称
        /// </summary>
        public string LastButtonText
        {
            get;
            set;
        }

        /// <summary>
        /// 上一组按钮显示的名称
        /// </summary>
        public string PrevGroupText
        {
            get;
            set;
        }

        /// <summary>
        /// 下一组按钮显示的名称
        /// </summary>
        public string NextGroupText
        {
            get;
            set;
        }

        /// <summary>
        /// 跳转按钮文本
        /// </summary>
        public string SwipeButtonText
        {
            get;
            set;
        }

        /// <summary>
        /// 分页控件的分页信息模块的样式名称
        /// </summary>
        public string PagerLableStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 分页控件的跳转功能模块的样式名称
        /// </summary>
        public string PagerSwipeStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 页码高亮样式名称
        /// </summary>
        public string LightPagerStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 首页的超链接Html
        /// </summary>
        public string FirstPageLinkHtml
        {
            get
            {
                return BuildSplitString(FirstButtonText, 1 > TotalPage ? TotalPage : 1, Index <= 1 ? PagerElementEnum.UnPage : PagerElementEnum.First);
            }
        }

        public string PagerBoxElType { get; set; }

        public bool IsHasBoxEl { get; set; }

        /// <summary>
        /// 获取生成好的分页字符串
        /// </summary>
        public string PagerSplitString
        {
            get
            {
                TotalPage = TotalPage <= 1 ? 1 : TotalPage;
                Index = Index > TotalPage ? TotalPage : Index;
                Index = Index <= 1 ? 1 : Index;

                var backVal = new StringBuilder();
                backVal.AppendFormat("<{0} class=\"gkPage\">", PagerBoxElType);

                if (IsHasBoxEl)
                    backVal.AppendFormat("<span class=\"{0}\">", PagerLableStyle);
                backVal.Append(PagerSplitInfo);
                if (IsHasBoxEl)
                    backVal.AppendFormat("</span>");

                if (IsHasBoxEl)
                    backVal.AppendFormat("<span id=\"{0}\" class=\"{1}\">", PagerLableStyle, PagerSplitStyle);
                if (IsShowFirst)
                    backVal.Append(FirstPageLinkHtml);

                if (IsShowPrevButton)
                    backVal.Append(BuildSplitString(PrevButtonText, Index - 1, Index <= 1 ? PagerElementEnum.UnPage : PagerElementEnum.Prev));

                if (Index - GroupCount > 0 && IsShowPrevGroupButton)
                {
                    backVal.Append(BuildSplitString(PrevGroupText, Index - GroupCount, PagerElementEnum.PrevGroup));
                }

                int count = 0;
                for (int i = StartPageIndex; i <= EndPageIndex; i++)
                {
                    backVal.Append(BuildSplitString(i.ToString(), i, i == Index ? PagerElementEnum.LightPage : PagerElementEnum.Page));
                    count++;
                    if (count >= PageCount)
                        break;
                }

                if (Index + GroupCount <= EndPageIndex && IsShowNextGroupButton)
                {
                    backVal.Append(BuildSplitString(NextGroupText, Index + GroupCount, PagerElementEnum.NextGroup));
                }

                if (IsShowNextButton)
                    backVal.Append(BuildSplitString(NextButtonText, Index + 1, Index >= TotalPage ? PagerElementEnum.UnPage : PagerElementEnum.Next));

                if (IsShowLast)
                    backVal.Append(BuildSplitString(LastButtonText, TotalPage, Index >= TotalPage ? PagerElementEnum.UnPage : PagerElementEnum.Last));
                if (IsHasBoxEl)
                    backVal.AppendFormat("</span>");

                if (IsHasBoxEl)
                    backVal.AppendFormat("<span class=\"{0}\">", PagerLableStyle);
                if (IsShowSwipe)
                    backVal.Append(BuildSwipeString());
                if (IsHasBoxEl)
                    backVal.AppendFormat("</span>");

                backVal.AppendFormat("</{0}>", PagerBoxElType);
                return backVal.ToString();
            }
        }

        /// <summary>
        /// 首页号
        /// </summary>
        protected int StartPageIndex
        {
            get
            {
                var startPageIndex = Math.Max(Index, Index - TotalPage / 2);
                if (startPageIndex + PageCount > TotalPage)
                    startPageIndex -= (startPageIndex + PageCount - TotalPage - 1);
                else if (startPageIndex - PageCount <= 0)
                    startPageIndex = 1;
                else
                    startPageIndex -= PageCount / 2;

                if (startPageIndex < 1)
                    startPageIndex = 1;
                if (startPageIndex > TotalPage)
                    startPageIndex = TotalPage;

                return startPageIndex;
            }
        }

        /// <summary>
        /// 尾页号
        /// </summary>
        protected int EndPageIndex
        {
            get
            {
                if (TotalPage > PageCount)
                    return Math.Min(TotalPage, Index + TotalPage / 2);
                else
                    return TotalPage;
            }
        }

        /// <summary>
        /// 页码参数名称
        /// </summary>
        public string PageIndexName
        {
            get;
            set;
        }

        /// <summary>
        /// 每页记录数参数名称
        /// </summary>
        public string PageSizeName
        {
            get;
            set;
        }

        /// <summary>
        /// 首页的Html
        /// </summary>
        public string FirstPagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 尾页的Html
        /// </summary>
        public string LastPagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 上一页的Html
        /// </summary>
        public string PrevPagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 下一页的Html
        /// </summary>
        public string NextPagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 上一组的Html
        /// </summary>
        public string PrevGroupHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 下一组的Html
        /// </summary>
        public string NextGroupHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 普通页码的Html代码
        /// </summary>
        public string PagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 当前页码的Html代码
        /// </summary>
        public string CurrentPagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 不可用的页码Html代码
        /// </summary>
        public string UnEnablePagerSplitHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 分页状态栏模板
        /// </summary>
        public string PagerStatueHtml
        {
            get;
            set;
        }

        /// <summary>
        /// 页码样式名称(ClassName)
        /// </summary>
        public string PagerSplitStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 分页跳转文本框的样式名称
        /// </summary>
        public string SwipePageInputStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 分页跳转按钮的样式名称
        /// </summary>
        public string SwipePageButtonStyle
        {
            get;
            set;
        }

        /// <summary>
        /// 当前Url模板
        /// </summary>
        public string UrlTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// 生成分页的Url的方法
        /// </summary>
        public Func<string, int, PagerElementEnum, string> PagerUrlFunc { get; set; }

        /// <summary>
        /// 构建分页链接
        /// </summary>
        /// <param name="text">分页显示的文本</param>
        /// <param name="index">分页标签的页码</param>
        /// <param name="isUnEnable">是否为可用页码</param>
        /// <returns></returns>
        protected string BuildSplitString(string text, int index, PagerElementEnum pType)
        {
            if (!PagerUrlFunc.IsNullOrEmpty())
                return PagerUrlFunc(text, index, pType);

            if (pType == PagerElementEnum.UnPage)
            {
                return UnEnablePagerSplitHtml.Replace("{Text}", text);
            }
            else
            {
                var url = GetUrlByIndex(index);
                return GetTemplateString(pType).Replace("{Url}", url).Replace("{Text}", text);
            }
        }

        /// <summary>
        /// 根据页码类型获取Html模板
        /// </summary>
        /// <param name="pElType"></param>
        /// <returns></returns>
        public string GetTemplateString(PagerElementEnum pElType)
        {
            var val = string.Empty;
            switch (pElType)
            {
                case PagerElementEnum.First:
                    val = FirstPagerSplitHtml;
                    break;
                case PagerElementEnum.Last:
                    val = LastPagerSplitHtml;
                    break;
                case PagerElementEnum.LightPage:
                    val = CurrentPagerSplitHtml;
                    break;
                case PagerElementEnum.Next:
                    val = NextPagerSplitHtml;
                    break;
                case PagerElementEnum.NextGroup:
                    val = NextGroupHtml;
                    break;
                case PagerElementEnum.Page:
                    val = PagerSplitHtml;
                    break;
                case PagerElementEnum.Prev:
                    val = PrevPagerSplitHtml;
                    break;
                case PagerElementEnum.PrevGroup:
                    val = PrevGroupHtml;
                    break;
                case PagerElementEnum.UnPage:
                    val = UnEnablePagerSplitHtml;
                    break;
            }
            return val;
        }

        /// <summary>
        /// 构建跳转功能
        /// </summary>
        /// <returns>构建跳转功能</returns>
        public string BuildSwipeString()
        {
            return string.Format("<input id=\"gk_swipe_index\" class=\"{0}\" /><input type=\"button\" class=\"{1}\" value=\"{3}\" onclick=\"location='{2}'+document.getElementById('gk_swipe_index').value;\" />", SwipePageInputStyle, SwipePageButtonStyle, UrlTemplate, SwipeButtonText);
        }

        /// <summary>
        /// 分页状态信息
        /// </summary>
        public string PagerSplitInfo
        {
            get
            {
                return PagerStatueHtml.Replace("{TotalRecord}", TotalCount.ToString()).Replace("{Index}", (Index > TotalPage ? TotalPage : Index).ToString()).Replace("{TotalPages}", TotalPage.ToString()).Replace("{PageSize}", Size.ToString());
                //return string.Format("总记录数：{2} 当前页:{0} 总页数:{1}", PageIndex > TotalPage ? TotalPage : PageIndex, TotalPage, TotalCount);
            }
        }

        /// <summary>
        /// 获取指定页码的Url
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetUrlByIndex(int index)
        {
            var url = "/" + Controller + "/" + Action;

            if (!Area.IsNullOrEmpty())
                url = "/" + Area + url;

            var urlText = GetUrlParameterString(index);
            //var param = string.Format("?{0}={1}&{2}={3}", PageIndexName, index, PageSizeName, PageSize);
            //if (UrlTemplate.IsNullOrEmpty())
            //{
            //    UrlTemplate = url + urlText.ToString();
            //    UrlTemplate = string.Format("{0}&{1}=", new Regex("\\?" + PageIndexName + "=(\\d)*&").Replace(UrlTemplate, "?"), PageIndexName);
            //}
            return url + urlText.ObjectToString();
        }

        /// <summary>
        /// 获取url上的所有附加参数
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public StringBuilder GetUrlParameterString(int index)
        {
            var param = string.Format("?{0}={1}&{2}={3}", PageIndexName, index, PageSizeName, Size);
            var urlText = new StringBuilder(param);
            if (!ParamObj.IsNullOrEmpty())
            {

                IDictionary<string, object> valueDictionary = null;
                if (ParamObj is IDictionary<string, object>)
                    valueDictionary = ParamObj as IDictionary<string, object>;
                else
                    valueDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(ParamObj);
                foreach (var key in valueDictionary.Keys)
                {
                    if (key.NewEquals(PageSizeName) || key.NewEquals(PageIndexName))
                        continue;
                    urlText.AppendFormat("&{0}={1}", key, valueDictionary[key]);
                }
            }
            return urlText;
        }
    }
}
