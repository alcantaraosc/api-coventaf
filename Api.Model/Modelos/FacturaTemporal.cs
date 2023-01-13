
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class FacturaTemporal
    {
        [Required]
        [StringLength(50)]
        public string Factura { get; set; }
        [Required]
        [StringLength(50)]
        public string ArticuloID { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TipoCambio { get; set; }
        [StringLength(50)]
        public string Bodega { get; set; }
        public int Consecutivo { get; set; }
        [StringLength(50)]
        public string CodigoBarra { get; set; }
        public decimal Cantidad { get; set; }
        [StringLength(200)]
        public string Descripcion { get; set; }
        [StringLength(50)]
        public string Unidad { get; set; }
        public decimal Precio { get; set; }        
        public decimal Descuento { get; set; }                
    }
}
