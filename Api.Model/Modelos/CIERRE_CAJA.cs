using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{        
    public class CIERRE_CAJA
    {       
        public CIERRE_CAJA()
        {
            //this.CIERRE_INFO_TARJ = new HashSet<CIERRE_INFO_TARJ>();
            //this.CIERRE_POS = new HashSet<CIERRE_POS>();
        }

        //[Key]
        //[Column(Order = 0)]
        [StringLength(20)]
        public string Num_Cierre_Caja { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [StringLength(20)]
        public string Caja { get; set; }
        public DateTime Fecha_Apertura { get; set; }
        public string Cajero_Cierre { get; set; }
        public DateTime? Fecha_Cierre { get; set; }
        public string Estado { get; set; }
        public DateTime? Fecha_Anulacion { get; set; }
        public string Cajero_Apertura { get; set; }
        public string Doc_Fiscal { get; set; }
        public string Documento { get; set; }
        public string Correlativo { get; set; }
        public byte NoteExistsFlag { get; set; }
        public DateTime RecordDate { get; set; }
        public string RowPointer { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public System.DateTime CreateDate { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CIERRE_INFO_TARJ> CIERRE_INFO_TARJ { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CIERRE_POS> CIERRE_POS { get; set; }
    }
}
