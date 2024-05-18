using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;



namespace DataAccessLayer.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProjectUser> ProjectUsers{ get; set; }

        public  DbSet<DailyLog> DailyLogs { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<TaskModel> Tasks { get; set; }
        public DbSet<TaskUser> TaskUsers { get; set; }
        public DbSet<ProjectClient> ProjectClients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Auditor> Auditors { get; set;}
        

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<DailyLog>()
        //        .HasOne(l => l.User)
        //        .WithMany(u => u.DailyLogs)
        //        .HasForeignKey(l => l.UserId);
        //}
    }

}
