using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    //tabla de tipo de cambio
     public class MONEDA_HIST
    {

        [StringLength(4)]
        //Key
        public string Moneda { get; set; }
        //key
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(25)]        
        public string Usuario { get; set; }
        [Required]
        public decimal Monto { get; set; }
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

    }
}
