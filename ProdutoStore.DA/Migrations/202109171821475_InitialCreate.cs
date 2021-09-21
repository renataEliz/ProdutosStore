namespace ProdutoStore.DA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCategoriaProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 250),
                        Descricao = c.String(nullable: false, maxLength: 250),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblProduto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoriaId = c.Int(nullable: false),
                        Nome = c.String(nullable: false, maxLength: 250),
                        Descricao = c.String(nullable: false, maxLength: 250),
                        Ativo = c.Boolean(nullable: false),
                        Perecivel = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblCategoriaProduto", t => t.CategoriaId)
                .Index(t => t.CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProduto", "CategoriaId", "dbo.tblCategoriaProduto");
            DropIndex("dbo.tblProduto", new[] { "CategoriaId" });
            DropTable("dbo.tblProduto");
            DropTable("dbo.tblCategoriaProduto");
        }
    }
}
