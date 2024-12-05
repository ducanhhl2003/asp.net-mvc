namespace moi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateSale : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Sale", "MaGiamGia", c => c.String());
            AddColumn("dbo.tb_Sale", "GiamGia", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Sale", "GiamGia");
            DropColumn("dbo.tb_Sale", "MaGiamGia");
        }
    }
}
