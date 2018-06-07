namespace JedjanguiWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mouvemebt : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.MouvementFonds", "CODEFONDMEMEBRE", "dbo.FondMembres");
            //RenameColumn(table: "dbo.MouvementFonds", name: "CODEFONDMEMEBRE", newName: "CODEFONDMEMBRE");
            //RenameIndex(table: "dbo.MouvementFonds", name: "IX_CODEFONDMEMEBRE", newName: "IX_CODEFONDMEMBRE");
            //DropPrimaryKey("dbo.FondMembres");
            //AddColumn("dbo.FondMembres", "CODEFONDMEMBRE", c => c.Long(nullable: false, identity: true));
            //AddPrimaryKey("dbo.FondMembres", "CODEFONDMEMBRE");
            //AddForeignKey("dbo.MouvementFonds", "CODEFONDMEMBRE", "dbo.FondMembres", "CODEFONDMEMBRE");
            //DropColumn("dbo.FondMembres", "CODEFONDMEMEBRE");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FondMembres", "CODEFONDMEMEBRE", c => c.Long(nullable: false, identity: true));
            DropForeignKey("dbo.MouvementFonds", "CODEFONDMEMBRE", "dbo.FondMembres");
            DropPrimaryKey("dbo.FondMembres");
            DropColumn("dbo.FondMembres", "CODEFONDMEMBRE");
            AddPrimaryKey("dbo.FondMembres", "CODEFONDMEMEBRE");
            RenameIndex(table: "dbo.MouvementFonds", name: "IX_CODEFONDMEMBRE", newName: "IX_CODEFONDMEMEBRE");
            RenameColumn(table: "dbo.MouvementFonds", name: "CODEFONDMEMBRE", newName: "CODEFONDMEMEBRE");
            AddForeignKey("dbo.MouvementFonds", "CODEFONDMEMEBRE", "dbo.FondMembres", "CODEFONDMEMEBRE");
        }
    }
}
