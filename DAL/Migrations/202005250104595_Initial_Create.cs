namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    NickName = c.String(),
                    CountComments = c.Int(nullable: false),
                    Status = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Text = c.String(),
                    DateTime = c.DateTime(nullable: false),
                    PostId = c.Int(nullable: false),
                    AuthorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.AuthorId);

            CreateTable(
                "dbo.Posts",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Text = c.String(),
                    DateTime = c.DateTime(nullable: false),
                    CategoryId = c.Int(nullable: false),
                    AuthorId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Authors", t => t.AuthorId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.AuthorId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Discription = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Tags",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Text = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Pictures",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Image = c.Binary(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.TagComments",
                c => new
                {
                    Tag_Id = c.Int(nullable: false),
                    Comment_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Tag_Id, t.Comment_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Comments", t => t.Comment_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Comment_Id);

            CreateTable(
                "dbo.TagPosts",
                c => new
                {
                    Tag_Id = c.Int(nullable: false),
                    Post_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("dbo.Tags", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Posts", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.Comments", "AuthorId", "dbo.Authors");
            DropForeignKey("dbo.TagPosts", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.TagPosts", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.TagComments", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.TagComments", "Tag_Id", "dbo.Tags");
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.TagPosts", new[] { "Post_Id" });
            DropIndex("dbo.TagPosts", new[] { "Tag_Id" });
            DropIndex("dbo.TagComments", new[] { "Comment_Id" });
            DropIndex("dbo.TagComments", new[] { "Tag_Id" });
            DropIndex("dbo.Posts", new[] { "AuthorId" });
            DropIndex("dbo.Posts", new[] { "CategoryId" });
            DropIndex("dbo.Comments", new[] { "AuthorId" });
            DropIndex("dbo.Comments", new[] { "PostId" });
            DropTable("dbo.TagPosts");
            DropTable("dbo.TagComments");
            DropTable("dbo.Pictures");
            DropTable("dbo.Tags");
            DropTable("dbo.Categories");
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
            DropTable("dbo.Authors");
        }
    }
}
