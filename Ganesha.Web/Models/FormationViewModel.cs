using System;

namespace Ganesha.Web.Models {
    public class FormationViewModel {
        public int FrmId { get; set; }
        public string FrmLib { get; set; }
        public string FrmDescription { get; set; }
        public string FrmLieu { get; set; }
        public string FrmPublic { get; set; }
        public decimal FrmPrix { get; set; }
        public byte[] FrmImage { get; set; }
        public DateTime FrmDateDebut { get; set; }
        public DateTime FrmDateFin { get; set; }
        public bool FrmIsActive { get; set; }
    }
}