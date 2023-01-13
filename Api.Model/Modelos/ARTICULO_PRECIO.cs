using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{   
    public class ARTICULO_PRECIO
    {

        //[Key]
        //[Column(Order = 0)]
        //[StringLength(12)]      
        [Column(TypeName = "varchar(12)")]
        public string NombreEstadoCivil { get; set; }
        public string NIVEL_PRECIO { get; set; }

        //[Key]
        //[Column(Order = 1)]
        [StringLength(1)]
        public string MONEDA { get; set; }

        //[Key]
        //[Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VERSION { get; set; }

        //[Key]
        //[Column(Order = 3)]
        [StringLength(20)]
        public string ARTICULO { get; set; }

        //[Key]
        //[Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VERSION_ARTICULO { get; set; }

        [Required]
        public decimal PRECIO { get; set; }

        [Required]
        [StringLength(1)]
        public string ESQUEMA_TRABAJO { get; set; }

        public decimal? MARGEN_MULR { get; set; }
        [Required]
        public decimal MARGEN_UTILIDAD { get; set; }
        [Required]
        public DateTime FECHA_INICIO { get; set; }
        [Required]
        public DateTime FECHA_FIN { get; set; }

        public DateTime? FECHA_ULT_MODIF { get; set; }

        [StringLength(25)]
        public string USUARIO_ULT_MODIF { get; set; }

        public decimal? MARGEN_UTILIDAD_MIN { get; set; }

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

        //public virtual ARTICULO ARTICULO1 { get; set; }

        //public virtual VERSION_NIVEL VERSION_NIVEL { get; set; }
    }
}
