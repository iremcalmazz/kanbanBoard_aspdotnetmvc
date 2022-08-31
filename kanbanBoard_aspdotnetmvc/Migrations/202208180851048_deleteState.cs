namespace kanbanBoard_aspdotnetmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteState : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Columns", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Columns", "State", c => c.String());
        }
    }
}
