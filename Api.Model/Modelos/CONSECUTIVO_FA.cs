using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{    
    public class CONSECUTIVO_FA
    {
        
        public CONSECUTIVO_FA()
        {
            //CONSECUFA_USUARIO = new HashSet<CONSECUFA_USUARIO>();
            //CONSECUTIVO = new HashSet<CONSECUTIVOS>();
            //DESPACHO = new HashSet<DESPACHO>();
            //SUBTIPO_DOC_CC = new HashSet<SUBTIPO_DOC_CC>();
            //GLOBALES_POS = new HashSet<GLOBALES_POS>();
        }

        //[Key]
        [StringLength(10)]
        public string CODIGO_CONSECUTIVO { get; set; }

        [Required]
        [StringLength(25)]
        public string USUARIO_ULT { get; set; }

        [Required]
        [StringLength(40)]
        public string DESCRIPCION { get; set; }

        [Required]
        [StringLength(1)]
        public string TIPO { get; set; }

        public short LONGITUD { get; set; }

        [Required]
        [StringLength(50)]
        public string VALOR_CONSECUTIVO { get; set; }

        [StringLength(50)]
        public string MASCARA { get; set; }

        public DateTime FECHA_HORA_ULT { get; set; }

        [Required]
        [StringLength(250)]
        public string FORMATO { get; set; }

        [Required]
        [StringLength(1)]
        public string USA_DESPACHOS { get; set; }

        [Required]
        [StringLength(1)]
        public string USA_ESQUEMA_CAJAS { get; set; }

        [Required]
        [StringLength(50)]
        public string VALOR_MAXIMO { get; set; }

        public int NUMERO_COPIAS { get; set; }

        [StringLength(30)]
        public string ORIGINAL { get; set; }

        [StringLength(30)]
        public string COPIA1 { get; set; }

        [StringLength(30)]
        public string COPIA2 { get; set; }

        [StringLength(30)]
        public string COPIA3 { get; set; }

        [StringLength(30)]
        public string COPIA4 { get; set; }

        [StringLength(30)]
        public string COPIA5 { get; set; }

        [StringLength(30)]
        public string REIMPRESION { get; set; }

        [StringLength(20)]
        public string RESOLUCION { get; set; }

        [StringLength(25)]
        public string SERIE { get; set; }

        [StringLength(254)]
        public string DE_CONS_RPT { get; set; }

        [StringLength(50)]
        public string VALOR_INICIAL { get; set; }

        [StringLength(254)]
        public string DE_CC_RPT { get; set; }

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

        public int? MATRICULA_MERCANTIL { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CONSECUFA_USUARIO> CONSECUFA_USUARIO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CONSECUTIVOS> CONSECUTIVO { get; set; }

        //public virtual RESOLUCION_DOC_ELECTRONICO RESOLUCION_DOC_ELECTRONICO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DESPACHO> DESPACHO { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SUBTIPO_DOC_CC> SUBTIPO_DOC_CC { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GLOBALES_POS> GLOBALES_POS { get; set; }
    }
}
