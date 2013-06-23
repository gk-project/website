using GkwCn.Domains;
using GkwCn.Domains.Business;
using GkwCn.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.ViewaModels
{
    public class TradeListViewModel:BaseListViewModel<Trade>
    {
        public int? Type { get; set; }

        public TradeType TradeType
        {
            get
            {
                if (Type != null && Type.HasValue)
                    return (TradeType)Type.Value;
                throw new ArgumentNullException("不能将空值转换成TradeType类型");
            }
        }
    }
}
