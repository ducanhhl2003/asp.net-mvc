namespace moi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tb_Sale",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tb_Sale");
        }
    }
}
