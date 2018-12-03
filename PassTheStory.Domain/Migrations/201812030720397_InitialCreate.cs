namespace PassTheStory.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryId = c.Guid(nullable: false),
                        StoryName = c.String(),
                        NextAuthor = c.String(),
                        IsFinished = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.StoryId);
            
            CreateTable(
                "dbo.StoryParts",
                c => new
                    {
                        PartId = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        PartNumber = c.Int(nullable: false),
                        PartText = c.String(nullable: false),
                        Author = c.String(),
                        IsEnd = c.Boolean(nullable: false),
                        StoryId = c.Guid(nullable: false),
                        StoryName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.Stories", t => t.StoryId, cascadeDelete: true)
                .Index(t => t.StoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryParts", "StoryId", "dbo.Stories");
            DropIndex("dbo.StoryParts", new[] { "StoryId" });
            DropTable("dbo.StoryParts");
            DropTable("dbo.Stories");
        }
    }
}
