using Com.Mulei.Model;
using Com.Mulei.Model.Response;
using Com.Mulei.Service.Impl;
using Com.Mulei.Service.Interface;
using Com.Mulei.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;

namespace Com.Mulei.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// such interface shall be initialized when app start by any IoC framework
        /// </summary>
       public IUserInfoService UserInfoService { get; set; }

        [HttpGet]
        public HttpResponseMessage Login(string userName, string pwd)
        {

            if (!UserInfoService.Validate(userName, pwd))
            {
                return ToHttpResponse(MessageResult.Failed("login failed"));
            }
            //todo: expired time should be configurable
            var ticket = new FormsAuthenticationTicket(0, userName, DateTime.Now,
                            DateTime.Now.AddHours(1), true, string.Format("{0}&{1}", userName, pwd),
                            FormsAuthentication.FormsCookiePath);
            var oUser = new UserInfo { UserName = userName, Password = pwd, Ticket = FormsAuthentication.Encrypt(ticket) };
  
            var identity = new UserIdentity(oUser);
            var principal = new System.Security.Principal.GenericPrincipal(identity, null);

            
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }

            return ToHttpResponse(MessageResult.Ok(oUser, "login succeed"));
        }


    }
}
