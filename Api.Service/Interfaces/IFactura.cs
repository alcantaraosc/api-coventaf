using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public  interface IFactura
    {
        public Task<List<Facturas>> ListarFacturasAsync(FiltroFactura filtroFactura, ResponseModel responseModel);
        public Task<List<FacturaTemporal>> ListarFacturaTemporalesAsync(FiltroFactura filtroFactura, ResponseModel responseModel);
        public Task<string> ObtenerNoFactura(ResponseModel responseModel);
        public Task<List<TIPO_TARJETAS>> ListarTipoTarjeta(ResponseModel responseModel);
        public Task<List<CONDICION_PAGO>> ListarCondicionPago(ResponseModel responseModel);
        public bool ModeloUsuarioEsValido(ViewModelFacturacion model, ResponseModel responseModel);     
        public Task<int> InsertOrUpdateCierreCaja(ResponseModel responseModel, CIERRE_CAJA model);
        public Task<int> InsertOrUpdateFacturaTemporal( FacturaTemporal model, ResponseModel responseModel);      
        public Task<int> InsertOrUpdateFactura(ViewModelFacturacion model, ResponseModel responseModel);
        public Task<int> EliminarFacturaTemporal(ResponseModel responseModel, string noFactura, string articulo);
    }
}
