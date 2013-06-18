using GkwCn.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GkwCn.Models.Commands
{
    public class ChangePasswordCmd : ICommand
    {
        public int Id { get; set; }

        public string LoginName { get; set; }

        public string OldPassword { get; set; }

        public string Password { get; set; }

        public string RePassword { get; set; }

        public ChangePasswordCmd(int id,string lname,string oldpwd,string pwd,string rpwd)
        {
            this.Id = id;
            this.LoginName = lname;
            this.OldPassword = oldpwd;
            this.Password = pwd;
            this.RePassword = rpwd;
        }

        public ChangePasswordCmd() { }
    }
}