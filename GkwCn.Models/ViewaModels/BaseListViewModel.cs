using GkwCn.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.ViewModels
{
    public class BaseListViewModel<T>
    {
        public BaseListViewModel() { }

        public BaseListViewModel(IEnumerable<T> list, BasePager page)
        {
            this.ListValue = list;
            this.Page = page;
        }

        public IEnumerable<T> ListValue { get; set; }

        public BasePager Page { get; set; }
    }
}
