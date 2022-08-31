namespace kanbanBoard_aspdotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cards", "Order", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cards", "Order", c => c.Int(nullable: false));
        }
    }
}
