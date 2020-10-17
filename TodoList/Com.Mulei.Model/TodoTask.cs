using Com.Mulei.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Mulei.Model
{
    public class TodoTask   :ModelBase    
    {
        public string Name { get; set; }

        public string Description    { get; set; }

        public TaskState Status { get; set; }


    }
}
