using GkwCn.Domains.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.ViewModels
{
    public class NewsListViewModel : BaseListViewModel<News>
    {

        public int? Type { get; set; }

    }
}
