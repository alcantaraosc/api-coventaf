using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ResponseModel
    {
        //1=EXITO, 0=NO EXITO, -1=ERROR
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
        public bool SetFocus { get; set; } = false;
        public string ResultIdString { get; set; }
        public string NombreInput { get; set; }
        public object Data { get; set; }
        public object DataAux { get; set; }
    }
}
