namespace MiCode.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSchoolIntoDomain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Standards", "School_Id", c => c.Int());
            CreateIndex("dbo.Standards", "School_Id");
            AddForeignKey("dbo.Standards", "School_Id", "dbo.Schools", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Standards", "School_Id", "dbo.Schools");
            DropIndex("dbo.Standards", new[] { "School_Id" });
            DropColumn("dbo.Standards", "School_Id");
            DropTable("dbo.Schools");
        }
    }
}
