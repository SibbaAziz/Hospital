namespace Hospital.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class employeeUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "IsAbsent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "IsAbsent");
        }
    }
}
