using Com.Mulei.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Model
{
    public class UserIdentity : IIdentity
    {
        public UserInfo User { get; set; }

        public UserIdentity(UserInfo user)
        {
            User = user;
        }


        public string Name
        {
            get { return User.UserName; }
        }

        public string AuthenticationType
        {
            get { return "Basic"; }
        }

        public bool IsAuthenticated
        {
            get { return true; }
        }
    }



}
