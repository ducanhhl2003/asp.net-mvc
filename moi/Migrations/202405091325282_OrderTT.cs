namespace moi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Order", "OrderTT", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Order", "OrderTT");
        }
    }
}
