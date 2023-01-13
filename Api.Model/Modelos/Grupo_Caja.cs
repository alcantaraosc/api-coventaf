using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Grupo_Caja
    {
        [Required]
        [Column(TypeName = "varchar(6)")]
        public string Grupo { get; set; }
        [Required]
        [Column(TypeName ="varchar(6)")]        
        public string Caja { get; set; }
        [Required]        
        public byte NoteExistsFlag { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required]
        public Guid RowPointer { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]       
        public string CreatedBy { get; set; }
        [Required]
        [Column(TypeName = "varchar(30)")]
        public string UpdatedBy { get; set; }
        [Required]        
        public DateTime CreateDate { get; set; }
        
    }
}
