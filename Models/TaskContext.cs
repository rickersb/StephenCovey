using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
