using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains
{
    public enum UserActionEnum : byte
    {
        Register = 0,
        Login = 1,
        Logout = 2,
        ChangePassword = 3
    }

    public class RegUserLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Message { get; set; }

        public UserActionEnum Type { get; set; }

        public DateTime CreateTime { get; set; }

        public RegUserLog()
        {
        }

        public RegUserLog(int uid, string msg, UserActionEnum type, DateTime ctime)
        {
            this.UserId = uid;
            this.Message = msg;
            this.Type = type;
            this.CreateTime = ctime;
        }
    }
}
