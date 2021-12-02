namespace W2SB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proprietarios",
                c => new
                    {
                        ProprietarioId = c.Long(nullable: false, identity: true),
                        Nome = c.String(),
                        Celular = c.String(),
                        Endereco = c.String(),
                        Cidade = c.String(),
                        Uf = c.String(),
                        Rg = c.String(),
                        Cpf = c.String(),
                    })
                .PrimaryKey(t => t.ProprietarioId);
            
            CreateTable(
                "dbo.Veiculoes",
                c => new
                    {
                        VeiculoId = c.Long(nullable: false, identity: true),
                        Marca = c.String(),
                        Modelo = c.String(),
                        Ano = c.String(),
                        Cor = c.String(),
                        Combustivel = c.String(),
                        ProprietarioId = c.Long(),
                    })
                .PrimaryKey(t => t.VeiculoId)
                .ForeignKey("dbo.Proprietarios", t => t.ProprietarioId)
                .Index(t => t.ProprietarioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Veiculoes", "ProprietarioId", "dbo.Proprietarios");
            DropIndex("dbo.Veiculoes", new[] { "ProprietarioId" });
            DropTable("dbo.Veiculoes");
            DropTable("dbo.Proprietarios");
        }
    }
}
