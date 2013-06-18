using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GkwCn.Models.Commands
{
    public class RegisterCmd:ICommand
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public string Email { get; set; }
    }
}