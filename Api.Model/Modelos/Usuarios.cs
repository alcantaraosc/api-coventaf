using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Usuarios
    {

        public Usuarios()
        {
          
            RolesUsuarios = new HashSet<RolesUsuarios>();
        }

        [Key]
        [StringLength(25)]
        public string Usuario { get; set; }
        [NotMapped]
        public bool NuevoUsuario { get; set; }

        [Required]
        [StringLength(100)]
       public string Nombre { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(1)]
        public string Activo { get; set; }

        [Required]
        [StringLength(1)]
        public string Req_Cambio_Clave { get; set; }

        [Required]
        public short Frecuencia_Clave { get; set; }

        [Required]
        public DateTime Fecha_Ult_Clave { get; set; } 

        [Required]
        public Int16 Max_Intentos_Conex { get; set; }

        [StringLength(68)]
        public string Clave { get; set; }
        [StringLength(249)]
        public string Correo_Electronico { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo_Acceso { get; set; }
        
        [StringLength(25)]
        public string Celular { get; set; }

        [StringLength(256)]
        public string Tipo_Personalizado { get; set; }

        [Required]        
        public byte NoteExistsFlag { get; set; }

        [Required]
        public DateTime RecordDate { get; set; }

        [Required]
        public Guid RowPointer { get; set; }
      
        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public string ClaveCifrada { get; set; }

        [NotMapped]
        public string ConfirmarClaveCifrada { get; set; }

        public string Grupo { get; set; }

        public virtual ICollection<RolesUsuarios> RolesUsuarios { get; set; }


    }
}
