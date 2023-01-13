using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.COVENTAF.Controllers.PuntoDeVenta
{
    //[ApiController]
    //[Route("[controller]")]

    [ApiController]
    [Route("api/factura")]
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador
    public class FacturaController : Controller
    {
        //declarar la interfaz
        private readonly IFactura _serviceFactura;
        private readonly IBodega _dataBodega;
        private readonly IFormaPago _dataFormaPago;
        private readonly IMoneda_Hist _dataMonedaHist;



        public FacturaController(IFactura serviceFactura, IBodega dataBodega, IFormaPago dataFormaPago, IMoneda_Hist dataMonedaHist)
        {
            this._serviceFactura = serviceFactura;
            this._dataBodega = dataBodega;
            this._dataFormaPago = dataFormaPago;
            this._dataMonedaHist = dataMonedaHist;
        }

        // GET: FacturaController
        [HttpPost("ListarFacturas")]
        public async Task<ActionResult<ResponseModel>> ListarFacturas(FiltroFactura filtroFactura)
        {
            ResponseModel responseModel = new ResponseModel();
            responseModel.Data = new List<Facturas>();

            try
            {
                responseModel.Data = await _serviceFactura.ListarFacturasAsync(filtroFactura, responseModel);
            }
            catch (Exception ex)
            {
                //0 para indicar que existe algun error en la consulta 
                responseModel.Exito = -1;
                //indicar el mensaje del error
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }


        [HttpGet("llenarComboxFacturaAsync")]
        public async Task<ActionResult<ListarDrownList>> llenarComboxFacturaAsync()
        {
            var listarCombox = new ListarDrownList();
            listarCombox.bodega = new List<BODEGA>();
            listarCombox.FormaPagos = new List<FORMA_PAGOS>();
            listarCombox.CondicionPago = new List<CONDICION_PAGO>();
            listarCombox.NoFactura = "";
            var responseModel = new ResponseModel();
            
            try
            {
                var moneda_Hist = new MONEDA_HIST();
                moneda_Hist =  await _dataMonedaHist.ObtenerTipoCambioDelDiaAsync(responseModel);
                listarCombox.tipoDeCambio = moneda_Hist.Monto;
                //obtener la lista de bodegas que estan activas
                listarCombox.bodega = await _dataBodega.ListarBodegasAsync(responseModel);
                listarCombox.FormaPagos = (List<FORMA_PAGOS>)await _dataFormaPago.ListarFormaDePago(responseModel);
                responseModel = null;
                responseModel = new ResponseModel();
                listarCombox.NoFactura = await _serviceFactura.ObtenerNoFactura(responseModel);
                listarCombox.TipoTarjeta = await _serviceFactura.ListarTipoTarjeta(responseModel);
                listarCombox.CondicionPago = await _serviceFactura.ListarCondicionPago(responseModel);
                listarCombox.Exito = 1;
                listarCombox.Mensaje = "Consulta Exitosa";
            
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                listarCombox.Exito = -1;
                listarCombox.Mensaje = ex.Message;
            }

            return listarCombox;
        }

        [HttpDelete("EliminarArticuloDetalleFacturaAsync/{noFactura}/{articulo}")]
        public async Task<ActionResult<ResponseModel>> EliminarArticuloDetalleFacturaAsync(string noFactura, string articulo)
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new FacturaTemporal();
            try
            {
                responseModel.Data = await _serviceFactura.EliminarFacturaTemporal(responseModel, noFactura, articulo);
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }



        [HttpGet("ObtenerNoFacturaAsync")]
        public async Task<ActionResult<ResponseModel>> ObtenerNoFacturaAsync()
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new object();

            try
            {
                responseModel.Data = await _serviceFactura.ObtenerNoFactura(responseModel);          
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }


       
        [HttpPost("GuardarCierrCaja")]
        public async Task<ActionResult<ResponseModel>> GuardarCierrCaja(CIERRE_CAJA model)
        {
            var result = 0;
            ResponseModel responseModel = new ResponseModel();           
            try
            {
                result = await _serviceFactura.InsertOrUpdateCierreCaja(responseModel, model);
                responseModel.Exito = 1;
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return Ok(responseModel);
        }

        [HttpPost("GuardarDatosFacturaTemporal")]
        public async Task<ActionResult<ResponseModel>> GuardarDatosFacturaTemporal(FacturaTemporal model)
        {
            var result = 0;
            ResponseModel responseModel = new ResponseModel();
            try
            {                
                result = await _serviceFactura.InsertOrUpdateFacturaTemporal(model, responseModel);
                responseModel.Exito = 1;
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return Ok(responseModel);
        }
                
  
        [HttpPost("GuardarFacturaAsync")]
        //public async Task<ActionResult<ResponseModel>> GuardarFacturaAsync(ViewModelFacturacion model)
        public async Task<ActionResult<ResponseModel>> GuardarFacturaAsync(ViewModelFacturacion model)
        {
            var responseModel = new ResponseModel();

            int result = 0;
            try
            {
                //validar que el modelo este correcto antes de guardar en la base de datos
                if (_serviceFactura.ModeloUsuarioEsValido(model, responseModel))
                {
                    result = await _serviceFactura.InsertOrUpdateFactura(model, responseModel);
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;
        }
        


        // GET: FacturaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FacturaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacturaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}
