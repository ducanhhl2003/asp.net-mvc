namespace moi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class follower : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tb_OrderDetail", "FollowOrder_Id", "dbo.FollowOrders");
            DropIndex("dbo.tb_OrderDetail", new[] { "FollowOrder_Id" });
            AddColumn("dbo.FollowOrders", "trangthai", c => c.String());
            AddColumn("dbo.tb_Order", "FollowId", c => c.Int(nullable: false));
            AddColumn("dbo.tb_Order", "FollowOrder_Id", c => c.Int());
            CreateIndex("dbo.tb_Order", "FollowOrder_Id");
            AddForeignKey("dbo.tb_Order", "FollowOrder_Id", "dbo.FollowOrders", "Id");
            DropColumn("dbo.tb_OrderDetail", "FollowId");
            DropColumn("dbo.tb_OrderDetail", "FollowOrder_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tb_OrderDetail", "FollowOrder_Id", c => c.Int());
            AddColumn("dbo.tb_OrderDetail", "FollowId", c => c.Int(nullable: false));
            DropForeignKey("dbo.tb_Order", "FollowOrder_Id", "dbo.FollowOrders");
            DropIndex("dbo.tb_Order", new[] { "FollowOrder_Id" });
            DropColumn("dbo.tb_Order", "FollowOrder_Id");
            DropColumn("dbo.tb_Order", "FollowId");
            DropColumn("dbo.FollowOrders", "trangthai");
            CreateIndex("dbo.tb_OrderDetail", "FollowOrder_Id");
            AddForeignKey("dbo.tb_OrderDetail", "FollowOrder_Id", "dbo.FollowOrders", "Id");
        }
    }
}
