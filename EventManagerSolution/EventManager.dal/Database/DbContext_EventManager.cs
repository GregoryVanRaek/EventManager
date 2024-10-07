using EventManager.dal.Database.Configuration;
using EventManager.dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.dal.Database;

public class DbContext_EventManager : DbContext
{
    public DbContext_EventManager(DbContextOptions options) : base(options){}
    
    #region Db entity
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Days> Days { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<Participation> Participation { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<User> User { get; set; }
    #endregion
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CommentConfig());
        modelBuilder.ApplyConfiguration(new DaysConfig());
        modelBuilder.ApplyConfiguration(new EventConfig());
        modelBuilder.ApplyConfiguration(new ParticipationConfig());
        modelBuilder.ApplyConfiguration(new RoleConfig());
        modelBuilder.ApplyConfiguration(new ThemeConfig());
        modelBuilder.ApplyConfiguration(new UserConfig());
    }
}