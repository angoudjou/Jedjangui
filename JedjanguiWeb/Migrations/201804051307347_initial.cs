namespace JedjanguiWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Associations",
                c => new
                {
                    CODEASSO = c.Long(nullable: false, identity: true),
                    NOMASSO = c.String(nullable: false),
                    BUTASSO = c.String(nullable: false),
                    EMAIL = c.String(),
                    SIGLEASSO = c.String(nullable: false),
                    DATECREATIONASS = c.DateTime(),
                    DATEAJOUTER = c.DateTime(),
                    STATUTASSO = c.Boolean(nullable: false),
                    COMPTABANKASSO = c.String(),
                    BANQUEASSO = c.String(),
                    SLOGANASSO = c.String(),
                    ADDRESSEASSO = c.String(),
                    MOTPASSEASSO = c.String(),
                    LIEURENCONTRE = c.String(),
                    CODEUTILISATEUR = c.String(),
                })
                .PrimaryKey(t => t.CODEASSO);

            CreateTable(
                "dbo.Exercices",
                c => new
                {
                    CODEEXO = c.Long(nullable: false, identity: true),
                    CODEASSO = c.Long(),
                    DEBUTEXO = c.DateTime(),
                    FINEXO = c.DateTime(),
                    STATUTEXO = c.Boolean(nullable: false),
                    NOMEXO = c.String(),
                    FINSAISIE = c.DateTime(),
                })
                .PrimaryKey(t => t.CODEEXO)
                .ForeignKey("dbo.Associations", t => t.CODEASSO)
                .Index(t => t.CODEASSO);

            CreateTable(
                "dbo.InscrisExercices",
                c => new
                {
                    CODEINSCRIPTION = c.Long(nullable: false, identity: true),
                    CODEMEMBRE = c.Long(nullable: false),
                    CODEEXO = c.Long(nullable: false),
                    POSTEMEMBREEXO = c.String(),
                    DATEINSCRIPTION = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.CODEINSCRIPTION)
                .ForeignKey("dbo.Exercices", t => t.CODEEXO, cascadeDelete: true)
                .ForeignKey("dbo.Membres", t => t.CODEMEMBRE, cascadeDelete: true)
                .Index(t => t.CODEMEMBRE)
                .Index(t => t.CODEEXO);

            CreateTable(
                "dbo.FondMembres",
                c => new
                {
                    CODEFONDMEMEBRE = c.Long(nullable: false, identity: true),
                    CODEINSCRIPTIONEXERCICE = c.Long(nullable: false),
                    CODEFOND = c.Long(nullable: false),
                    DEBIT = c.Double(nullable: false),
                    CREDIT = c.Double(nullable: false),
                    SOLDE = c.Double(nullable: false),
                })
                .PrimaryKey(t => t.CODEFONDMEMEBRE)
                .ForeignKey("dbo.Fonds", t => t.CODEFOND, cascadeDelete: true)
                .ForeignKey("dbo.InscrisExercices", t => t.CODEINSCRIPTIONEXERCICE, cascadeDelete: true)
                .Index(t => t.CODEINSCRIPTIONEXERCICE)
                .Index(t => t.CODEFOND);

            CreateTable(
                "dbo.Fonds",
                c => new
                {
                    CODEFOND = c.Long(nullable: false, identity: true),
                    CODEASSO = c.Long(nullable: false),
                    NOMFOND = c.String(),
                    COMPTEBANQUEFOND = c.String(),
                    BANQUE = c.String(),
                    OBJECTIFFOND = c.String(),
                    OBLIGATOIRE = c.Boolean(),
                    TYPEFOND = c.String(),
                })
                .PrimaryKey(t => t.CODEFOND)
                .ForeignKey("dbo.Associations", t => t.CODEASSO, cascadeDelete: true)
                .Index(t => t.CODEASSO);

            CreateTable(
                "dbo.Membres",
                c => new
                {
                    CODEMEMBRE = c.Long(nullable: false, identity: true),
                    CODEASSO = c.Long(nullable: false),
                    NOMMEMBRE = c.String(),
                    DATEADEHSIONMEMEBRE = c.DateTime(),
                    DATEDEMISSION = c.DateTime(),
                    DATENAISSANCEMEMBRE = c.DateTime(),
                    STATUTMEMBRE = c.Boolean(),
                    FONCTIONMEMBRE = c.String(),
                    TELMEMBRE = c.String(),
                    RESIDENCEMEMEBRE = c.String(),
                    ADRESSEMEMEBRE = c.String(),
                    SEXEMEMBRE = c.String(),
                    STATUTMATRIMONIALE = c.String(),
                    EMAILMEMBRE = c.String(),
                    NOMBREENFANT = c.Long(),
                    NOTEMEMBRE = c.String(),
                    TITREMEMBRE = c.String(),
                    TYPEMEMBRE = c.String(),
                    ELOGE = c.String(),
                    MATRICULE = c.String(),
                })
                .PrimaryKey(t => t.CODEMEMBRE)
                .ForeignKey("dbo.Associations", t => t.CODEASSO, cascadeDelete: true)
                .Index(t => t.CODEASSO);

            CreateTable(
                "dbo.Seances",
                c => new
                {
                    CODESEANCE = c.Long(nullable: false, identity: true),
                    CODEEXO = c.Long(nullable: false),
                    DATESEANCE = c.DateTime(),
                    DEBUTSEANCE = c.DateTime(),
                    FINSEANCE = c.DateTime(),
                    STATUTSEANCE = c.String(),
                    NOMSEANCE = c.String(),
                    LIEUSEANCE = c.String(),
                    COMPTERENDUSEANCE = c.String(),
                })
                .PrimaryKey(t => t.CODESEANCE)
                .ForeignKey("dbo.Exercices", t => t.CODEEXO, cascadeDelete: true)
                .Index(t => t.CODEEXO);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Seances", "CODEEXO", "dbo.Exercices");
            DropForeignKey("dbo.InscrisExercices", "CODEMEMBRE", "dbo.Membres");
            DropForeignKey("dbo.Membres", "CODEASSO", "dbo.Associations");
            DropForeignKey("dbo.FondMembres", "CODEINSCRIPTIONEXERCICE", "dbo.InscrisExercices");
            DropForeignKey("dbo.FondMembres", "CODEFOND", "dbo.Fonds");
            DropForeignKey("dbo.Fonds", "CODEASSO", "dbo.Associations");
            DropForeignKey("dbo.InscrisExercices", "CODEEXO", "dbo.Exercices");
            DropForeignKey("dbo.Exercices", "CODEASSO", "dbo.Associations");
            DropIndex("dbo.Seances", new[] { "CODEEXO" });
            DropIndex("dbo.Membres", new[] { "CODEASSO" });
            DropIndex("dbo.Fonds", new[] { "CODEASSO" });
            DropIndex("dbo.FondMembres", new[] { "CODEFOND" });
            DropIndex("dbo.FondMembres", new[] { "CODEINSCRIPTIONEXERCICE" });
            DropIndex("dbo.InscrisExercices", new[] { "CODEEXO" });
            DropIndex("dbo.InscrisExercices", new[] { "CODEMEMBRE" });
            DropIndex("dbo.Exercices", new[] { "CODEASSO" });
            DropTable("dbo.Seances");
            DropTable("dbo.Membres");
            DropTable("dbo.Fonds");
            DropTable("dbo.FondMembres");
            DropTable("dbo.InscrisExercices");
            DropTable("dbo.Exercices");
            DropTable("dbo.Associations");
        }
    }
}
