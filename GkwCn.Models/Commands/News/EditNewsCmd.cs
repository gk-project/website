using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Models.Commands
{
    public class EditNewsCmd:CreateNewsCmd
    {
        public int Id { get; set; }
    }
}
