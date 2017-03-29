using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ganesha.Core.Entities {

    [Table("t_formation_frm")]
    public class Formation {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("frm_id")]
        public int FrmId { get; set; }

        [Required]
        [Column("frm_lib")]
        public string FrmLib { get; set; }

        [Required]
        [Column("frm_dsc")]
        public string FrmDescription { get; set; }

        [Required]
        [Column("frm_lieu")]
        public string FrmLieu { get; set; }

        [Required]
        [Column("frm_public")]
        public string FrmPublic { get; set; }

        [Required]
        [Column("frm_putc")]
        public decimal FrmPrix { get; set; }

        [Column("frm_img")]
        public byte[] FrmImage { get; set; }

        [Column("frm_date_debut")]
        public DateTime FrmDateDebut { get; set; }

        [Column("frm_date_fin")]
        public DateTime FrmDateFin { get; set; }

        [Column("frm_isactive")]
        public bool FrmIsActive { get; set; }

    }
}