using BloggingSystem.DTO.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloggingSystemDatabase
{
    public class BloggingSystemDbContext:DbContext
    {
        public BloggingSystemDbContext(DbContextOptions<BloggingSystemDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Categories> Categories { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(d => d.UserRoleId);
                entity.HasOne(e => e.User)
                .WithMany(d => d.UserRole)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(d => d.Role)
                .WithMany(e => e.UserRole)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(p => p.UserId);
                entity.Property(p => p.UserName);
                entity.Property(p => p.Email);
                entity.Property(p => p.Password);
            });


            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.Property(p => p.RoleName);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoriesId);
                entity.Property(p => p.CategoriesName);
            });



            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.CommentId);


                entity.HasOne(o => o.Post)
                .WithMany(m => m.Comment)
                .HasForeignKey(f => f.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId);
                entity.HasOne(o => o.User)
                .WithMany(m => m.Post)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Cascade);


                entity.HasOne(o => o.Categories)
                .WithMany(m => m.Post)
                .HasForeignKey(f => f.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(p => p.CreatedBy);
                entity.Property(p => p.Describtion);
                entity.Property(p => p.Title);
            });



        }
       
    }
}
