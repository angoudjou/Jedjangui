namespace JedjanguiWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pret : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Fonds", "CODEASSO", "dbo.Associations");
            DropForeignKey("dbo.Membres", "CODEASSO", "dbo.Associations");
            DropForeignKey("dbo.InscrisExercices", "CODEEXO", "dbo.Exercices");
            DropForeignKey("dbo.Seances", "CODEEXO", "dbo.Exercices");
            DropForeignKey("dbo.FondMembres", "CODEINSCRIPTIONEXERCICE", "dbo.InscrisExercices");
            DropForeignKey("dbo.InscrisExercices", "CODEMEMBRE", "dbo.Membres");
            DropForeignKey("dbo.FondMembres", "CODEFOND", "dbo.Fonds");
            CreateTable(
                "dbo.Prets",
                c => new
                    {
                        CODEPRET = c.Long(nullable: false, identity: true),
                        CODEMEMBRE = c.Long(nullable: false),
                        CODEASSO = c.Long(nullable: false),
                        CODEFOND = c.Long(nullable: false),
                        MONTANTPRET = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MONTANTAREMBOURSER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MONTANTREMBOURSER = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DATEMISEENPLACE = c.DateTime(nullable: false),
                        SOLDEPRET = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DATEFINPRET = c.DateTime(nullable: false),
                        DUREEPRET = c.Long(nullable: false),
                        STATUTPRET = c.String(),
                        INTERETPRET = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DATEDEBUTPRET = c.DateTime(),
                    })
                .PrimaryKey(t => t.CODEPRET)
                .ForeignKey("dbo.Associations", t => t.CODEASSO)
                .ForeignKey("dbo.Fonds", t => t.CODEFOND)
                .ForeignKey("dbo.Membres", t => t.CODEMEMBRE)
                .Index(t => t.CODEMEMBRE)
                .Index(t => t.CODEASSO)
                .Index(t => t.CODEFOND);
            
            AddForeignKey("dbo.Fonds", "CODEASSO", "dbo.Associations", "CODEASSO");
            AddForeignKey("dbo.Membres", "CODEASSO", "dbo.Associations", "CODEASSO");
            AddForeignKey("dbo.InscrisExercices", "CODEEXO", "dbo.Exercices", "CODEEXO");
            AddForeignKey("dbo.Seances", "CODEEXO", "dbo.Exercices", "CODEEXO");
            AddForeignKey("dbo.FondMembres", "CODEINSCRIPTIONEXERCICE", "dbo.InscrisExercices", "CODEINSCRIPTIONEXERCICE");
            AddForeignKey("dbo.InscrisExercices", "CODEMEMBRE", "dbo.Membres", "CODEMEMBRE");
            AddForeignKey("dbo.FondMembres", "CODEFOND", "dbo.Fonds", "CODEFOND");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FondMembres", "CODEFOND", "dbo.Fonds");
            DropForeignKey("dbo.InscrisExercices", "CODEMEMBRE", "dbo.Membres");
            DropForeignKey("dbo.FondMembres", "CODEINSCRIPTIONEXERCICE", "dbo.InscrisExercices");
            DropForeignKey("dbo.Seances", "CODEEXO", "dbo.Exercices");
            DropForeignKey("dbo.InscrisExercices", "CODEEXO", "dbo.Exercices");
            DropForeignKey("dbo.Membres", "CODEASSO", "dbo.Associations");
            DropForeignKey("dbo.Fonds", "CODEASSO", "dbo.Associations");
            DropForeignKey("dbo.Prets", "CODEMEMBRE", "dbo.Membres");
            DropForeignKey("dbo.Prets", "CODEFOND", "dbo.Fonds");
            DropForeignKey("dbo.Prets", "CODEASSO", "dbo.Associations");
            DropIndex("dbo.Prets", new[] { "CODEFOND" });
            DropIndex("dbo.Prets", new[] { "CODEASSO" });
            DropIndex("dbo.Prets", new[] { "CODEMEMBRE" });
            DropTable("dbo.Prets");
            AddForeignKey("dbo.FondMembres", "CODEFOND", "dbo.Fonds", "CODEFOND", cascadeDelete: true);
            AddForeignKey("dbo.InscrisExercices", "CODEMEMBRE", "dbo.Membres", "CODEMEMBRE", cascadeDelete: true);
            AddForeignKey("dbo.FondMembres", "CODEINSCRIPTIONEXERCICE", "dbo.InscrisExercices", "CODEINSCRIPTIONEXERCICE", cascadeDelete: true);
            AddForeignKey("dbo.Seances", "CODEEXO", "dbo.Exercices", "CODEEXO", cascadeDelete: true);
            AddForeignKey("dbo.InscrisExercices", "CODEEXO", "dbo.Exercices", "CODEEXO", cascadeDelete: true);
            AddForeignKey("dbo.Membres", "CODEASSO", "dbo.Associations", "CODEASSO", cascadeDelete: true);
            AddForeignKey("dbo.Fonds", "CODEASSO", "dbo.Associations", "CODEASSO", cascadeDelete: true);
        }
    }
}
