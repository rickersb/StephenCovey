using System;
using System.ComponentModel.DataAnnotations;

namespace Covey.Models
{
    public class Task
    {
        [Key]
        [Required]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        public DateTime DueDate { get; set; }
        [Required]
        public int Quadrant { get; set; }
        
        public bool Completed { get; set; }

        // Foreign Key
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
