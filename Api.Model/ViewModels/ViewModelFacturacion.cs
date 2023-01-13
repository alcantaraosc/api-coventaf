using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ViewModelFacturacion
    {
        public Facturas Factura { get; set; }
        public List<FACTURA_LINEA> FacturaLinea { get; set; }
    }
}
