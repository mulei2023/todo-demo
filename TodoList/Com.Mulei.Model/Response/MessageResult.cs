using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Model.Response
{
    public class MessageResult
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }

        public static MessageResult Ok(dynamic data, string msg = "")
        {
            return new MessageResult()
            {
                Succeed = true,
                Data = data,
                Message = msg,

            };
        }


        public static MessageResult Failed(string msg = "")
        {
            return new MessageResult()
            {
                Succeed = false,
                Message = msg,

            };
        }
    }
}
