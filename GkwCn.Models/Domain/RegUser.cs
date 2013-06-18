using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GkwCn.Domains
{
    public enum UserStatue : byte
    {
        UnAuid = 0,
        Actiony = 1,
        VIP = 2,
    }

    public enum SexEnum : byte
    {
        UnSetting = 0,
        Male,
        Female
    }

    public class RegUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DomainStatue Statue { get; set; }

        [Required]
        public UserStatue Level { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 5)]
        public string LoginName { get; set; }

        [Required]
        [StringLength(16,MinimumLength=5)]
        public string Password { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(20)]
        public string Handset { get; set; }

        [MaxLength(100)]
        public string Address { get; set; }

        public SexEnum Sex { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }

        public DateTime? LastLoginTime { get; set; }

        /// <summary>
        /// 验证用户输入的两次密码是否相同
        /// </summary>
        /// <returns>是否验证通过</returns>
        public bool ValidationPassword(string pwd, string rPwd)
        {
            if (pwd == null || pwd != rPwd)
                return false;

            Password = DecodingPassword(pwd);
            return true;
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="oldpwd">老用户密码</param>
        /// <param name="npwd">新用户密码</param>
        /// <param name="rpwd">重复新用户密码</param>
        /// <returns>是否可以修改</returns>
        public bool ChangePassword(string oldpwd, string npwd, string rpwd)
        {
            if (Password == DecodingPassword(oldpwd) && ValidationPassword(npwd, rpwd))
                return true;
            return false;
        }

        /// <summary>
        /// 用户密码加密
        /// </summary>
        /// <param name="pwd">要加密的密码</param>
        /// <returns></returns>
        public string DecodingPassword(string pwd)
        {
            return pwd + "gkwcn";
        }

        /// <summary>
        /// 激活用户
        /// </summary>
        public void ActionyUser()
        {
            Level = UserStatue.Actiony;
        }
    }
}
