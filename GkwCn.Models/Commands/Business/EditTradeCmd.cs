using GkwCn.Domains;
using GkwCn.Domains.BaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands.Business
{
    public class EditTradeCmd : CreateTradeCmd
    {
        public int Id { get; set; }

    }
}
