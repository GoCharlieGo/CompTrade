namespace CompTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YEBEKE : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserProfile", "FistName", c => c.String());
            AlterColumn("dbo.UserProfile", "SecondName", c => c.String());
            AlterColumn("dbo.UserProfile", "ImgPath", c => c.String());
            AlterColumn("dbo.UserProfile", "Info", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserProfile", "Info", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfile", "ImgPath", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfile", "SecondName", c => c.String(nullable: false));
            AlterColumn("dbo.UserProfile", "FistName", c => c.String(nullable: false));
        }
    }
}
