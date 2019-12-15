namespace OneToManyList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactPersons",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        CompanyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ContactPersons", "CompanyId", "dbo.Companies");
            DropIndex("dbo.ContactPersons", new[] { "CompanyId" });
            DropTable("dbo.ContactPersons");
            DropTable("dbo.Companies");
        }
    }
}
