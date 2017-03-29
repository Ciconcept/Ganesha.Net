namespace Ganesha.Data.Migrations {
    using System.Data.Entity.Migrations;

    public partial class AddFormation1 : DbMigration {
        public override void Up() {
            AddColumn("dbo.t_formation_frm", "frm_isactive", c => c.Boolean(nullable: false));
        }

        public override void Down() {
            DropColumn("dbo.t_formation_frm", "frm_isactive");
        }
    }
}
