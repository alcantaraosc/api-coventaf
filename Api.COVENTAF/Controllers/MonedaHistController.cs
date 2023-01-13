using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.COVENTAF.Controllers
{
    [ApiController]
    [Route("api/monedahist")]
    [Authorize] //aquí estaríamos agregando a nivel 
    public class MonedaHistController : Controller
    {
        private readonly IMoneda_Hist _dataMoneda_Hist;

        public MonedaHistController(IMoneda_Hist dataMoneda_Hist)
        {
            this._dataMoneda_Hist = dataMoneda_Hist;
        }


        [HttpGet("ObtenerTipoCambioDelDiaAsync")]
        public async Task<ActionResult<ResponseModel>> ObtenerTipoCambioDelDiaAsync()
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new MONEDA_HIST();
            try
            {
                responseModel.Data = await _dataMoneda_Hist.ObtenerTipoCambioDelDiaAsync(responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;

        }
    }
}
