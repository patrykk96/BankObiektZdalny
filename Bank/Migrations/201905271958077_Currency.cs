namespace Bank.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Currency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Currency", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Currency");
        }
    }
}
