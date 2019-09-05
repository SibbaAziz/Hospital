namespace Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class planningUnit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlanningUnits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            AddColumn("dbo.Employees", "PlanningUnit_Id", c => c.Int());
            CreateIndex("dbo.Employees", "PlanningUnit_Id");
            AddForeignKey("dbo.Employees", "PlanningUnit_Id", "dbo.PlanningUnits", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlanningUnits", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Employees", "PlanningUnit_Id", "dbo.PlanningUnits");
            DropIndex("dbo.PlanningUnits", new[] { "Service_Id" });
            DropIndex("dbo.Employees", new[] { "PlanningUnit_Id" });
            DropColumn("dbo.Employees", "PlanningUnit_Id");
            DropTable("dbo.PlanningUnits");
        }
    }
}
