namespace SMN.Musicas.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicaomusica : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MUS_MUSICA",
                c => new
                    {
                        MSC_ID = c.Int(nullable: false, identity: true),
                        MSC_NOME = c.String(nullable: false),
                        ALB_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MSC_ID)
                .ForeignKey("dbo.ALB_ALBUNS", t => t.ALB_ID, cascadeDelete: true)
                .Index(t => t.ALB_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MUS_MUSICA", "ALB_ID", "dbo.ALB_ALBUNS");
            DropIndex("dbo.MUS_MUSICA", new[] { "ALB_ID" });
            DropTable("dbo.MUS_MUSICA");
        }
    }
}
