using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Funciones
    {
        public Funciones()
        {
            FuncionesRoles = new HashSet<FuncionesRoles>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int FuncionID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string NombreFuncion { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Codigo { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Descripcion { get; set; }

        [Required]
        public bool Activo { get; set; }

        [Column(TypeName = "datetime")]
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? FechaModificacion { get; set; }

        public virtual ICollection<FuncionesRoles> FuncionesRoles { get; set; }
    }
}
