namespace CompTrade.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfile : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FistName = c.String(),
                        SecondName = c.String(),
                        ImgPath = c.String(),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserProfile_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserProfile_Id");
            AddForeignKey("dbo.AspNetUsers", "UserProfile_Id", "dbo.UserProfile", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserProfile_Id", "dbo.UserProfile");
            DropIndex("dbo.AspNetUsers", new[] { "UserProfile_Id" });
            DropColumn("dbo.AspNetUsers", "UserProfile_Id");
            DropTable("dbo.UserProfile");
        }
    }
}
