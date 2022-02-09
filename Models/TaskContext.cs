using Microsoft.EntityFrameworkCore;
using System;

namespace Covey.Models
{
    public class TaskContext : DbContext
    {
        //Constructor
        public TaskContext (DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}
