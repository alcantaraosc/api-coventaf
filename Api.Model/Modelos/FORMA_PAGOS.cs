using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    
    public class FORMA_PAGOS
    {
        public FORMA_PAGOS()
        {
            //CLIENTE_FORMA_PAGO = new HashSet<CLIENTE_FORMA_PAGO>();
            //DES_BON_REGLA = new HashSet<DES_BON_REGLA>();
            //PAGO_POS = new HashSet<PAGO_POS>();
        }

        //[Key]        
        [StringLength(4)]
        public string Forma_Pago { get; set; }

        [StringLength(40)]
        public string Descripcion { get; set; }

        [StringLength(1)]
        public string Impresion_Doble { get; set; }

        public int? Cantidad { get; set; }

        [StringLength(40)]
        public string Formulario { get; set; }

        [Required]
        [StringLength(1)]
        public string Uso_Interno { get; set; }

        [Required]
        [StringLength(1)]
        public string Activo { get; set; }

        [StringLength(25)]
        public string Centro_Costo { get; set; }

        [StringLength(25)]
        public string Cuenta_Contable { get; set; }

        [StringLength(40)]
        public string Nombre_Campo1 { get; set; }

        [StringLength(40)]
        public string Nombre_Campo2 { get; set; }

        [Required]
        [StringLength(1)]
        public string Moneda_Reporte { get; set; }

        [Required]
        [StringLength(1)]
        public string Requiere_Autorizacion { get; set; }

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

        //public virtual CENTRO_COSTO CENTRO_COSTO1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CLIENTE_FORMA_PAGO> CLIENTE_FORMA_PAGO { get; set; }

        //public virtual CUENTA_CONTABLE CUENTA_CONTABLE1 { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DES_BON_REGLA> DES_BON_REGLA { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PAGO_POS> PAGO_POS { get; set; }
    }
}
