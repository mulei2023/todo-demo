using Com.Mulei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Mulei.Infrastructure.Encryption;
using Com.Mulei.Service.Interface;

namespace Com.Mulei.Service.Impl
{
    public class UserInfoService : IUserInfoService
    {
        public UserInfo GetUser(string userName)
        {
            //todo:get model from db by username
            return new UserInfo() { };
        }

        public bool Validate(string userName, string pwd)
        {
            if (userName == null || pwd == null)
            {
                return false;
            }

            var user = this.GetUser(userName);
            if (user == null)
            {
                return false;
            }
            if (Encyptor.Encrypt(pwd) != user.Password)
            {
                return false;
            }

            return true;
        }
    }
}
