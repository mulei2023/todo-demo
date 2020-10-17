using Com.Mulei.Model;
using Com.Mulei.Model.Request;
using Com.Mulei.Model.Response;
using Com.Mulei.Service.Impl;
using Com.Mulei.Service.Interface;
using Com.Mulei.Web.Attributes;
using Com.Mulei.Web.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Com.Mulei.Web.Controllers
{
    [RequestAuthorize]
    public class TasksController : ControllerBase
    {
        public ITaskService TaskService { get; set; }
        public ILoggerService LoggerService { get; set; }

        public IUserInfoService UserInfoService { get; set; }

        // GET api/values
        public HttpResponseMessage GetByUser()
        {
            try
            {
                var username = this.User.Identity.Name;
                var res = TaskService.GetTasksByUser(username);
                return ToHttpResponse(MessageResult.Ok(res, "get my tasks succeed"));
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex);
                return ToHttpResponse(MessageResult.Failed("get my tasks failed"));

            }

        }

        public HttpResponseMessage AddTask(TodoTaskReqParameter parameter)
        {
            try
            {
                var model = this.GetTaskModel(parameter);
                var res = TaskService.AddTask(model);
                return ToHttpResponse(MessageResult.Ok(res, "add task succeed"));
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex);
                return ToHttpResponse(MessageResult.Failed("add task failed"));

            }

        }

        /// <summary>
        /// complete one task
        /// </summary>
        /// <param name="taskId">table key</param>
        /// <returns></returns>
        public HttpResponseMessage CompleteTask(int taskId)
        {
            try
            {
                var res = TaskService.CloseTask(taskId);
                if (res)
                {
                    return ToHttpResponse(MessageResult.Ok(null, "task completed successfully"));
                }
                else
                {
                    return ToHttpResponse(MessageResult.Failed("complete task failed"));
                }
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex);
                return ToHttpResponse(MessageResult.Failed("complete task failed"));

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        private TodoTask GetTaskModel(TodoTaskReqParameter parameter)
        {
            //todo: actually, here has some transform from input parameter to model
            return new TodoTask();
        }



    }
}
