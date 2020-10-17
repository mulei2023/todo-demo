using Com.Mulei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Service.Interface
{
   public interface IUserInfoService
    {
        UserInfo GetUser(string userName);
        bool Validate(string userName,string pwd);
    }
}
