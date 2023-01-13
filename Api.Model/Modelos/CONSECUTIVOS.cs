using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{        
    public class CONSECUTIVOS
    {       
        public CONSECUTIVOS()
        {
            //CONSECUTIVO_USUARIO = new HashSet<CONSECUTIVO_USUARIO>();
            //REGIMENES = new HashSet<REGIMENES>();
        }

        //[Key]        
        [StringLength(10)]
        public string CONSECUTIVO { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        [Required]
        [StringLength(1)]
        public string ACTIVO { get; set; }

        public decimal LONGITUD { get; set; }

        [Required]
        [StringLength(40)]
        public string ENTIDAD { get; set; }

        [Required]
        [StringLength(50)]
        public string DOCUMENTO { get; set; }

        [StringLength(250)]
        public string FORMATO_IMPRESION_DETALLADO { get; set; }

        [StringLength(250)]
        public string FORMATO_IMPRESION_RESUMIDO { get; set; }

        [Required]
        [StringLength(50)]
        public string MASCARA { get; set; }

        [Required]
        [StringLength(50)]
        public string VALOR_INICIAL { get; set; }

        [Required]
        [StringLength(50)]
        public string VALOR_FINAL { get; set; }

        [Required]
        [StringLength(50)]
        public string ULTIMO_VALOR { get; set; }

        [Required]
        [StringLength(25)]
        public string ULTIMO_USUARIO { get; set; }

        public DateTime FECHA_HORA_ULT { get; set; }

        [StringLength(10)]
        public string CONSECUTIVO_NC { get; set; }

        public byte NoteExistsFlag { get; set; }

        public DateTime RecordDate { get; set; }

        public Guid RowPointer { get; set; }

        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }

        public DateTime CreateDate { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CONSECUTIVO_USUARIO> CONSECUTIVO_USUARIO { get; set; }

        //public virtual CONSECUTIVO_FA CONSECUTIVO_FA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<REGIMENES> REGIMENES { get; set; }
    }
}

