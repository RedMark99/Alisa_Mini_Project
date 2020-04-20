namespace jewelry_shop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Global : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        IDUsers = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.IDUsers);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
