namespace AgendaContatos_CF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialmigrate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telephones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Celular = c.String(),
                        Fixo = c.String(),
                        IdContato = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Contacts", t => t.IdContato, cascadeDelete: true)
                .Index(t => t.IdContato);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Telephones", "IdContato", "dbo.Contacts");
            DropIndex("dbo.Telephones", new[] { "IdContato" });
            DropTable("dbo.Telephones");
            DropTable("dbo.Contacts");
        }
    }
}
