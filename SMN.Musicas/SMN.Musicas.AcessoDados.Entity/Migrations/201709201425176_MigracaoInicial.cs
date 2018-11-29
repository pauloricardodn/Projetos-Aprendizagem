namespace SMN.Musicas.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracaoInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ALB_ALBUNS",
                c => new
                    {
                        ALB_ID = c.Int(nullable: false, identity: true),
                        ALB_NOME = c.String(nullable: false),
                        ALB_ANO = c.Int(nullable: false),
                        ALB_OBSERVACOES = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ALB_ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ALB_ALBUNS");
        }
    }
}
