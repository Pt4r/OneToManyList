namespace OneToManyList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ContactPersons", "CompanyId", "dbo.Companies");
            DropIndex("dbo.ContactPersons", new[] { "CompanyId" });
            AlterColumn("dbo.ContactPersons", "CompanyId", c => c.Guid());
            CreateIndex("dbo.ContactPersons", "CompanyId");
            AddForeignKey("dbo.ContactPersons", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPersons", "CompanyId", "dbo.Companies");
            DropIndex("dbo.ContactPersons", new[] { "CompanyId" });
            AlterColumn("dbo.ContactPersons", "CompanyId", c => c.Guid(nullable: false));
            CreateIndex("dbo.ContactPersons", "CompanyId");
            AddForeignKey("dbo.ContactPersons", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
