using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    /*aqui estan el nombre de la tienda, TIENDA OUTLET supermercado*/
    public class Grupos
    {
        [Required]
        [Column(TypeName = "varchar(6)")]
        public string Grupo { get; set; }
        
        [Column(TypeName = "varchar(40)")]
        public string Descripcion {get; set;} 
        [Required]
        [Column(TypeName = "varchar(1)")]
        public string Sucursal { get; set; }
        [Required]
        [Column(TypeName = "varchar(12)")]
        public string Nivel_Precio { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Direccion { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Telefono { get; set; }

    }
}
