using Microsoft.EntityFrameworkCore;

using Entity_Framework.Models;

namespace Entity_Framework
{
    public class TaskContext : DbContext
    {
        public DbSet<Category> Categories {get;set;}
        public DbSet<Models.Task> tasks {get;set;}

        public TaskContext(DbContextOptions<TaskContext>options):base(options){}

        //Uso de Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Category> categoryInit = new List<Category>();
            categoryInit.Add(new Category( ){CategoryId = Guid.Parse("3b085bfd-2240-4d4d-a6e8-e1f2155c1595"),
                                             CategoryName = "Activities to Do",
                                             CategoryImpact = 20,
                                            });
            categoryInit.Add(new Category( ){CategoryId = Guid.Parse("3b085bfd-2240-4d4d-a6e8-e1f2155c1502"),
                                             CategoryName = "Personal Activities ",
                                             CategoryImpact = 10});


           modelBuilder.Entity<Category>(Category =>
           {
            Category.ToTable("Category");
            Category.HasKey(p => p.CategoryId);
            Category.Property(p => p.CategoryName).IsRequired().HasMaxLength(150);
            Category.Property(p => p.CategoryDescription).IsRequired(false);
            Category.Property (p => p.CategoryImpact);
            Category.HasData(categoryInit);

           });
            List<Models.Task> taskInit = new List<Models.Task>();
            taskInit.Add(new Models.Task(){TaskId = Guid.Parse("3b085bfd-2240-4d4d-a6e8-e1f2155c1510"),
                                           CategoryId = Guid.Parse("3b085bfd-2240-4d4d-a6e8-e1f2155c1595"), 
                                           PriorityTask = Priority.Medium,
                                           TaskTitle = "pay the internet",
                                           TaskDate = DateTime.Now,
                                           });
            taskInit.Add(new Models.Task(){TaskId = Guid.Parse("3b085bfd-2240-4d4d-a6e8-e1f2155c1511"),
                                           CategoryId = Guid.Parse("3b085bfd-2240-4d4d-a6e8-e1f2155c1502"), 
                                           PriorityTask = Priority.Low,
                                           TaskTitle = "Wash My Shoes",
                                           TaskDate = DateTime.Now,
                                           });
           modelBuilder.Entity<Models.Task>(Task =>
           {
            Task.ToTable("Task");
            Task.HasKey(p => p.TaskId);
            //Do ForeignKey
            Task.HasOne (p => p.Category).WithMany(p => p.Task).HasForeignKey(p => p.CategoryId); 
            Task.Property(p => p.TaskTitle).IsRequired().HasMaxLength(200);
            Task.Property(p => p.TaskDescription).IsRequired(false);
            Task.Property(p => p.PriorityTask);
            Task.Property(p => p.TaskDate);

            Task.Ignore(p => p.resum);

            Task.HasData(taskInit);


           });
        }
    }

}
