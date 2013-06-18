using GkwCn.Domains.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.ViewModels
{
    public class ProductListViewModel:BaseListViewModel<Product>
    {
        public int? CompanyId { get; set; }

        public string CompanyName { get; set; }

        public int? BrandId { get; set; }

        public int? ProductTypeId { get; set; }

        public int? PublishUserId { get; set; }
    }
}
