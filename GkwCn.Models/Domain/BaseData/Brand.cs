using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains.BaseData
{
    public class Brand:BaseSingleData
    {
        public int CompanyId { get; set; }

        public int LogoId { get; set; }
    }
}
