namespace Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manager_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Manager_Id)
                .Index(t => t.Manager_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Job = c.String(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Manager_Id = c.Int(),
                        Department_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Manager_Id)
                .ForeignKey("dbo.Departments", t => t.Department_Id)
                .Index(t => t.Manager_Id)
                .Index(t => t.Department_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "Department_Id", "dbo.Departments");
            DropForeignKey("dbo.Services", "Manager_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Departments", "Manager_Id", "dbo.Employees");
            DropIndex("dbo.Services", new[] { "Department_Id" });
            DropIndex("dbo.Services", new[] { "Manager_Id" });
            DropIndex("dbo.Employees", new[] { "Service_Id" });
            DropIndex("dbo.Departments", new[] { "Manager_Id" });
            DropTable("dbo.Services");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
