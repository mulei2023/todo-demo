using Com.Mulei.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Mulei.Infrastructure.Encryption;
using Com.Mulei.Service.Interface;
using Com.Mulei.Infrastructure;
using MySql.Data.MySqlClient;

namespace Com.Mulei.Service.Impl
{
    public class TaskService : ITaskService
    {
        public ILoggerService LoggerService { get; set; }


        public TodoTask AddTask(TodoTask todoTask)
        {
            throw new NotImplementedException();
        }

        public bool CloseTask(int taskId)
        {
            try
            {
                var status = (int)TaskState.Done;
                var sql = "update task set status=@status where id=@id";
                var parameters = new MySqlParameter[] { new MySqlParameter("@status", status), new MySqlParameter("@id", taskId) };
                MysqlHelper.ExecuteNonQuery(sql, parameters);
                return true;
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex);
                return false;
            }

        }

        public IList<TodoTask> GetTasksByUser(string userName)
        {
            try
            {
                var sql = "select name,decription,status from task a " +
                    " join ref_user_task b on a.id=b.task_id " +
                    " where b.user_name=@userName";
                var parameters = new MySqlParameter[] { new MySqlParameter("@userName", userName) };
                var dt= MysqlHelper.GetDataTable(sql, parameters);
                return dt.ToList<TodoTask>();
             
            }
            catch (Exception ex)
            {
                LoggerService.LogError(ex);
                return null;
            }
        }
    }
}
