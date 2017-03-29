namespace Ganesha.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.t_formation_frm", "frm_img", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.t_formation_frm", "frm_img", c => c.Binary(nullable: false));
        }
    }
}
