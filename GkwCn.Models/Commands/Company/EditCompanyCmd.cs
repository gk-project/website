using GkwCn.Domains;
using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands
{
    public class EditCompanyCmd : CreateCompanyCmd
    {
        public int Id { get; set; }
    }
}
