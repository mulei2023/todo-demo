using Com.Mulei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Service.Interface
{
   public interface ITaskService
    {
        /// <summary>
        /// get login user's tasks
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        IList<TodoTask> GetTasksByUser(string userName);
        
        /// <summary>
        /// save one new task
        /// </summary>
        /// <param name="todoTask"></param>
        /// <returns></returns>
        TodoTask AddTask(TodoTask todoTask);

        /// <summary>
        /// complete the task
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        bool CloseTask(int taskId);
    }
}
