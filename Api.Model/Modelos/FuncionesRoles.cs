using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class FuncionesRoles
    {
        [Required]
        public int FuncionID { get; set; }
        [NotMapped]
        public string NombreFuncion { get; set; }
        [Required]        
        public int RolID { get; set; }
        [NotMapped]
        public string NombreRol { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime FechaCreacion { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }

        [ForeignKey("FuncionID")]
        public virtual Funciones Funciones { get; set; }

        [ForeignKey("RolID")]
        public virtual Roles Roles { get; set; }
    }
}
