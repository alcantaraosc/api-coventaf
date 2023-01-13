using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    /*En la base de datos esta tabla llama vendedor, pero se refiere a la bodega*/

    public class BODEGA
    {
                
        public BODEGA()
        {
            //this.ARTICULO_COMPRA = new HashSet<ARTICULO_COMPRA>();
            //this.ARTICULO_SERIE_POS = new HashSet<ARTICULO_SERIE_POS>();
            //this.DOC_POS_LINEA = new HashSet<DOC_POS_LINEA>();
            //this.USUARIO_BODEGA = new HashSet<USUARIO_BODEGA>();
            //this.CAJA_POS = new HashSet<CAJA_POS>();
            //this.DESPACHO_DETALLE = new HashSet<DESPACHO_DETALLE>();
            //this.EMBARQUE_LINEA = new HashSet<EMBARQUE_LINEA>();
            //this.EXISTENCIA_BODEGA = new HashSet<EXISTENCIA_BODEGA>();
            //this.FACTURA_LINEA = new HashSet<FACTURA_LINEA>();
            //this.SP_PRONOSTICO_DETALLE = new HashSet<SP_PRONOSTICO_DETALLE>();
            //this.BODEGA_ENCARGADO = new HashSet<BODEGA_ENCARGADO>();
            //this.COST_STD_BATCH = new HashSet<COST_STD_BATCH>();
            //this.COSTO_STD_DESGL = new HashSet<COSTO_STD_DESGL>();
            //this.EXISTENCIA_CIERRE = new HashSet<EXISTENCIA_CIERRE>();
            //this.GLOBALES_AM = new HashSet<GLOBALES_AM>();
            //this.GLOBALES_FA = new HashSet<GLOBALES_FA>();
            //this.GLOBALES_CO = new HashSet<GLOBALES_CO>();
            //this.GLOBALES_POS = new HashSet<GLOBALES_POS>();
            //this.INCONSIST_INV_POS = new HashSet<INCONSIST_INV_POS>();
            //this.LOCALIZACION = new HashSet<LOCALIZACION>();
            //this.ORDEN_COMPRA_LINEA = new HashSet<ORDEN_COMPRA_LINEA>();
            //this.ORDEN_COMPRA = new HashSet<ORDEN_COMPRA>();
            //this.ORDEN_TRABAJO = new HashSet<ORDEN_TRABAJO>();
            //this.PEDIDO = new HashSet<PEDIDO>();
            //this.PEDIDO_LINEA = new HashSet<PEDIDO_LINEA>();
            //this.PRONOSTICO_DETALLE = new HashSet<PRONOSTICO_DETALLE>();
            //this.TRASPASO_POS = new HashSet<TRASPASO_POS>();
            //this.TRASPASO_POS1 = new HashSet<TRASPASO_POS>();
        }

        //[Key]
        [Required]
        [StringLength(4)]
        public string Vendedor { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(1)]
        public string Activo { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_COMPRA> ARTICULO_COMPRA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ARTICULO_SERIE_POS> ARTICULO_SERIE_POS { get; set; }
        //public virtual BOD_CARGA_MANUF BOD_CARGA_MANUF { get; set; }
        //public virtual CONSECUTIVO_CI CONSECUTIVO_CI { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DOC_POS_LINEA> DOC_POS_LINEA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<USUARIO_BODEGA> USUARIO_BODEGA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CAJA_POS> CAJA_POS { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<DESPACHO_DETALLE> DESPACHO_DETALLE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EMBARQUE_LINEA> EMBARQUE_LINEA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EXISTENCIA_BODEGA> EXISTENCIA_BODEGA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<FACTURA_LINEA> FACTURA_LINEA { get; set; }
       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<SP_PRONOSTICO_DETALLE> SP_PRONOSTICO_DETALLE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BODEGA_ENCARGADO> BODEGA_ENCARGADO { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<COST_STD_BATCH> COST_STD_BATCH { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<COSTO_STD_DESGL> COSTO_STD_DESGL { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<EXISTENCIA_CIERRE> EXISTENCIA_CIERRE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GLOBALES_AM> GLOBALES_AM { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GLOBALES_FA> GLOBALES_FA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GLOBALES_CO> GLOBALES_CO { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<GLOBALES_POS> GLOBALES_POS { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<INCONSIST_INV_POS> INCONSIST_INV_POS { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<LOCALIZACION> LOCALIZACION { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ORDEN_COMPRA_LINEA> ORDEN_COMPRA_LINEA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ORDEN_COMPRA> ORDEN_COMPRA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<ORDEN_TRABAJO> ORDEN_TRABAJO { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PEDIDO> PEDIDO { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PEDIDO_LINEA> PEDIDO_LINEA { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PRONOSTICO_DETALLE> PRONOSTICO_DETALLE { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TRASPASO_POS> TRASPASO_POS { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<TRASPASO_POS> TRASPASO_POS1 { get; set; }
    }
}

