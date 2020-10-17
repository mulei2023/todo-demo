using Com.Mulei.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Model
{
    public class UserInfo:ModelBase
    {

        public string UserName { get; set; }


        public string Password { get; set; }
        public string Ticket { get; set; }

    }
}
