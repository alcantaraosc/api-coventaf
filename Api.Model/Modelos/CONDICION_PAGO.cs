using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class CONDICION_PAGO
    {
        [StringLength(4)]
        public string Condicion_Pago { get; set; }
        [Required]
        [StringLength(40)]
        public string Descripcion { get; set; }
        [Required]
        public int Dias_Neto { get; set; }
        [Required]
        [StringLength(1)]
        public string Pagos_Parciales { get; set; }

    }
}
