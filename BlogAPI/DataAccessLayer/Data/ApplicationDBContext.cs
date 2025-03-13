using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Likes> Likes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>()
     .HasOne(c => c.Post) // A Comment belongs to one Post
     .WithMany(p => p.Comments) // A Post can have many Comments
     .HasForeignKey(c => c.PostId) // The foreign key in the Comments table
     .OnDelete(DeleteBehavior.Cascade); // Cascade delete when the Post is deleted

            modelBuilder.Entity<Comments>()
                .HasOne(c => c.Reader) // A Comment belongs to one Reader (User)
                .WithMany(u => u.Comments) // A User can have many Comments
                .HasForeignKey(c => c.UserId) // The foreign key in the Comments table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete on User

            modelBuilder.Entity<Likes>()
                .HasOne(l => l.Readers) // A Like belongs to one Reader (User)
                .WithMany(u => u.Likes) // A User can have many Likes
                .HasForeignKey(l => l.UserId) // The foreign key in the Likes table
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete when the User is deleted

            modelBuilder.Entity<Likes>()
                .HasOne(l => l.Post) // A Like belongs to one Post
                .WithMany(p => p.Likes) // A Post can have many Likes
                .HasForeignKey(l => l.PostId) // The foreign key in the Likes table
                .OnDelete(DeleteBehavior.NoAction); // Prevent cascade delete on Post
        }

    }
   
}
