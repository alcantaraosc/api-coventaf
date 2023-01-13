using Api.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.ViewModels
{
    public class ListarDrownList
    {
        public int Exito { get; set; }
        public string Mensaje { get; set; }
        public string NoFactura { get; set; }
        public decimal tipoDeCambio { get; set; }
        public List<BODEGA> bodega { get; set; }
        public List<FORMA_PAGOS> FormaPagos { get; set; }
        public List<TIPO_TARJETAS> TipoTarjeta { get; set; }
        public List<CONDICION_PAGO> CondicionPago { get; set; }
    }
}
