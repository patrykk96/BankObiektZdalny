namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Provisions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.Int(nullable: false),
                        Target = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Provisions");
        }
    }
}
