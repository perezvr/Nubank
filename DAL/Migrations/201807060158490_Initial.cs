namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fatura",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataInicial = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lancamento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Categoria = c.String(),
                        Descricao = c.String(),
                        Parcela = c.Int(nullable: false),
                        NumParcelas = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FaturaId = c.Int(nullable: false),
                        ResponsavelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fatura", t => t.FaturaId)
                .ForeignKey("dbo.Responsavel", t => t.ResponsavelId)
                .Index(t => t.FaturaId)
                .Index(t => t.ResponsavelId);
            
            CreateTable(
                "dbo.Responsavel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lancamento", "ResponsavelId", "dbo.Responsavel");
            DropForeignKey("dbo.Lancamento", "FaturaId", "dbo.Fatura");
            DropIndex("dbo.Lancamento", new[] { "ResponsavelId" });
            DropIndex("dbo.Lancamento", new[] { "FaturaId" });
            DropTable("dbo.Responsavel");
            DropTable("dbo.Lancamento");
            DropTable("dbo.Fatura");
        }
    }
}
