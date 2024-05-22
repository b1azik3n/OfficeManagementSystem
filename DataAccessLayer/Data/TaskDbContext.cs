using DomainLayer.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;



namespace DataAccessLayer.Data
{
    public class TaskDbContext : DbContext
    { 
        private readonly ILogger<TaskDbContext> _logger;
        public TaskDbContext(DbContextOptions<TaskDbContext> options, ILogger<TaskDbContext> logger) : base(options)
        {
            _logger= logger;
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
        public override int SaveChanges()
        {
            LogChanges();
            var result = base.SaveChanges();
            LogChangesCompleted(result);
            return result;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            LogChanges();
            var result = await base.SaveChangesAsync(cancellationToken);
            LogChangesCompleted(result);
            return result;
        }

        private void LogChanges()
        {
            _logger.LogInformation("SaveChanges started at {Time}", DateTime.Now);
            foreach (var entry in ChangeTracker.Entries())
            {
                _logger.LogInformation("Entity {Entity} state {State}", entry.Entity.GetType().Name, entry.State);
            }
        }

        private void LogChangesCompleted(int result)
        {
            _logger.LogInformation("SaveChanges completed at {Time} with {Result} changes", DateTime.Now, result);
        }
    }
}


