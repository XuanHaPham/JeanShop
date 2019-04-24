namespace API.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class EntityConnection : IdentityDbContext<Account>
    {
        public EntityConnection()
            : base("EntityConnection")
        {
        }

        public static EntityConnection Create()
        {
            return new EntityConnection();
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventComment> EventComments { get; set; }
        public virtual DbSet<EventType> EventTypes { get; set; }
        public virtual DbSet<EventVolunteer> EventVolunteers { get; set; }
        public virtual DbSet<EventVolunteerType> EventVolunteerTypes { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsComment> NewsComments { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationMember> OrganizationMembers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUser>().ToTable("Account");

            modelBuilder.Entity<IdentityUserRole>().ToTable("AccountRole").HasKey(p => p.UserId);

            modelBuilder.Entity<IdentityUserLogin>().ToTable("AccountLogin").HasKey(p => p.UserId);

            modelBuilder.Entity<IdentityUserClaim>().ToTable("AccountClaim");

            modelBuilder.Entity<IdentityRole>().ToTable("Role");

            modelBuilder.Entity<Account>()
                .ToTable("Account");
            
            modelBuilder.Entity<Account>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Organizations)
                .WithOptional(e => e.Account)
                .HasForeignKey(e => e.Creator);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.OrganizationMembers)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventVolunteerTypes)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(true);
            

            modelBuilder.Entity<News>()
                .HasMany(e => e.NewsComments)
                .WithRequired(e => e.News)
                .WillCascadeOnDelete(true);
        }
    }
}
