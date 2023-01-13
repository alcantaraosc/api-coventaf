using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class TIPO_TARJETAS
    {
        [StringLength(12)]
        public string Tipo_Tarjeta { get; set; }
        
        [Required]
        [StringLength(1)]
        public string Tipo_Cobro { get; set; }
        [StringLength(100)]
        public string Assembly_Invocacion { get; set; }
        [Required]
        public byte NoteExistsFlag { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required]
        public Guid RowPointer { get; set; }
        [Required]
        [StringLength(30)]        
        public string CreatedBy { get; set; }
        [StringLength(30)]
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        
    }
}
