using Com.Mulei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace Com.Mulei.Web.Controllers.Base
{
    public class ControllerBase:ApiController
    {

        public UserIdentity Identity
        {
            get { return HttpContext.Current.User.Identity as UserIdentity; }
        }

        public HttpResponseMessage ToHttpResponse(object content)
        {
            
            return new HttpResponseMessage()
            {
                Content = new StringContent(System.Web.Helpers.Json.Encode(content), Encoding.UTF8, "application/json")
            };
        }
    }
}