using System;
using System.ComponentModel.DataAnnotations;

namespace Covey.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }
        public string CategoryType { get; set; }
    }
}
