using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class RolesUsuarios
    {
        [Required]      
        public int RolID { get; set; }
        [Required]
        [Column(TypeName = "varchar(25)")]
        public string UsuarioID { get; set; }

        [NotMapped]
        public string NombreRol { get; set; }
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }

        [ForeignKey("RolID")]
        public virtual Roles Roles { get; set; }
        [ForeignKey("UsuarioID")]
        public virtual Usuarios Usuarios { get; set; }
    }
}
