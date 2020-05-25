using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL.Migrations.Configuration;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base(@"Data Source=.\SQLSERVER;Initial Catalog=InetForum;Integrated Security=True")
        {
            Database.SetInitializer<DBContext>(new MyContextInitializer());
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Picture> Pictures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Author>()
            //   .HasMany(p => p.Posts)
            //   .WithRequired(p => p.Author);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.Posts)
                .WithRequired(x => x.Author)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Author>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Author)
                .HasForeignKey(x => x.AuthorId);

            modelBuilder.Entity<Category>()
                .HasMany(x => x.Posts)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId); 

            modelBuilder.Entity<Post>()
                .HasMany(x => x.Comments)
                .WithRequired(x => x.Post)
                .HasForeignKey(x => x.PostId);

            //modelBuilder.Entity<Post>()
            //    .HasMany(x => x.Tags)
            //    .WithRequired(x => x.Post)
            //    .HasForeignKey(x => x.PostId);

        }

    }
}
