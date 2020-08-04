using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskHandler.Data.Models
{
    [Serializable]
    public class TaskData
    {
        [Key]
        public int TaskID { get; set; }

        [Required]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan CreateTime { get; set; }

        public override string ToString()
        {
            return $"ID: {TaskID}, Description: {Description}, CreateTime: {CreateTime:hh\\:mm\\:ss\\.f}";
        }
    }
}
