namespace Ganesha.Data.Migrations {
    using System.Data.Entity.Migrations;

    public partial class AddFormation : DbMigration {
        public override void Up() {
            CreateTable(
                "dbo.t_formation_frm",
                c => new {
                    frm_id = c.Int(nullable: false, identity: true),
                    frm_lib = c.String(nullable: false, unicode: false),
                    frm_dsc = c.String(nullable: false, unicode: false),
                    frm_lieu = c.String(nullable: false, unicode: false),
                    frm_public = c.String(nullable: false, unicode: false),
                    frm_putc = c.Decimal(nullable: false, precision: 18, scale: 2),
                    frm_img = c.Binary(nullable: false),
                    frm_date_debut = c.DateTime(nullable: false, precision: 0),
                    frm_date_fin = c.DateTime(nullable: false, precision: 0),
                })
                .PrimaryKey(t => t.frm_id);

        }

        public override void Down() {
            DropTable("dbo.t_formation_frm");
        }
    }
}
