using System;

namespace TaskHandler.DataAccess.Models
{
    public class TaskData
    {
        public int TaskID { get; set; }

        public string Description { get; set; }

        public TimeSpan CreateTime { get; set; }
    }
}
