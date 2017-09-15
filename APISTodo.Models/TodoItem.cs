using System;

namespace ApisTodo.Models
{
    public class TodoItem
    {
        public int TodoId { get; set; }

        public string TodoTitle { get; set; }

        public string TodoDescrption { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? DueDate { get; set; }

        public DateTime UpdateTime { get; set; }

        public DateTime CompletedTime { get; set; }
    }
}
