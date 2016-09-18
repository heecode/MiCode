namespace MiCode.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedNameIntoBaseEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Standards", "Name", c => c.String());
            AddColumn("dbo.Students", "Name", c => c.String());
            AddColumn("dbo.Teachers", "Name", c => c.String());
            DropColumn("dbo.Standards", "StandardName");
            DropColumn("dbo.Students", "StudentName");
            DropColumn("dbo.Teachers", "TeacherName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "TeacherName", c => c.String());
            AddColumn("dbo.Students", "StudentName", c => c.String());
            AddColumn("dbo.Standards", "StandardName", c => c.String());
            DropColumn("dbo.Teachers", "Name");
            DropColumn("dbo.Students", "Name");
            DropColumn("dbo.Standards", "Name");
        }
    }
}
