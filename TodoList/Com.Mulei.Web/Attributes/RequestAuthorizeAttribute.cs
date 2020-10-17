using Com.Mulei.Model.Response;
using Com.Mulei.Service.Impl;
using Com.Mulei.Service.Interface;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Security;

namespace Com.Mulei.Web.Attributes
{
    public class RequestAuthorizeAttribute : AuthorizeAttribute
    {
        public IUserInfoService UserInfoService { get; set; }

       
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var authorization = actionContext.Request.Headers.Authorization;
            if ((authorization != null) && (authorization.Parameter != null))
            {
                var encryptTicket = authorization.Parameter;
                if (ValidateTicket(encryptTicket))
                {
                    base.IsAuthorized(actionContext);
                }
                else
                {
                    HandleUnauthorizedRequest(actionContext);
                }
            }
            //如果取不到身份验证信息，并且不允许匿名访问，则返回未验证401
            else
            {
                var attributes = actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().OfType<AllowAnonymousAttribute>();
                bool isAnonymous = attributes.Any(a => a is AllowAnonymousAttribute);
                if (isAnonymous) { base.OnAuthorization(actionContext); }
                else { HandleUnauthorizedRequest(actionContext); }

            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actioncontext)
        {
            base.HandleUnauthorizedRequest(actioncontext);


            //return 
            var response = actioncontext.Response = actioncontext.Response ?? new HttpResponseMessage();
            response.StatusCode = HttpStatusCode.Forbidden;
            var content = MessageResult.Failed("your request authentication is failed");

            response.Content = new StringContent(Json.Encode(content), Encoding.UTF8, "application/json");
        }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="ticket"></param>
       /// <returns></returns>
        private bool ValidateTicket(string ticket)
        {
            var strTicket = FormsAuthentication.Decrypt(ticket).UserData;
            var index = strTicket.IndexOf("&");
            string strUser = strTicket.Substring(0, index);
            string strPwd = strTicket.Substring(index + 1);
            var pwdValidate = UserInfoService.Validate(strUser, strPwd);

            if (!pwdValidate)
            {
                return false;
            }

            //check 1.if expired  2.if password is correct by password-algorithm
            return true;
        }
    }

}