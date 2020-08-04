using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHandler.Data.Models
{
    [Serializable]
    public class TaskData
    {
        public int TaskID { get; set; }

        [Required]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan CreateTime { get; set; }
    }
}
