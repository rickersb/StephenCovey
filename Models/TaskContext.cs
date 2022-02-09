using Microsoft.EntityFrameworkCore;
using System;

namespace Covey.Models
{
    public class TaskContext : DbContext
    {
        //Constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryType = "Home"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryType = "School"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryType = "Work"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryType = "Church"
                }
            );

        }
    }
}
