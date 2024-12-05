namespace moi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedabc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Wishlist", "ProductImage_Id", c => c.Int());
            CreateIndex("dbo.tb_Wishlist", "ProductImage_Id");
            AddForeignKey("dbo.tb_Wishlist", "ProductImage_Id", "dbo.tb_ProductImage", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tb_Wishlist", "ProductImage_Id", "dbo.tb_ProductImage");
            DropIndex("dbo.tb_Wishlist", new[] { "ProductImage_Id" });
            DropColumn("dbo.tb_Wishlist", "ProductImage_Id");
        }
    }
}
