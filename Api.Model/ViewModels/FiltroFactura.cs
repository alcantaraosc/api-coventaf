using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class FiltroFactura
    {
        [Required]
        public string Tipofiltro { get; set; }      
        [Column(TypeName = "date")]
        public DateTime? FechaInicio { get; set; }
        [Column(TypeName ="date")]
        public DateTime? FechaFinal { get; set; }
        public string Busqueda { get; set; }
    }
}
