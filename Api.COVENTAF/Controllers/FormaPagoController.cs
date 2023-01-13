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
    [Route("api/formapago")]
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador
    public class FormaPagoController : Controller
    {
        private readonly IFormaPago _dataFormaPago;

        public FormaPagoController(IFormaPago dataFormaPago)
        {
            this._dataFormaPago = dataFormaPago;
        }


        [HttpGet("ListarFormaPagoAsync")]
        public async Task<ActionResult<ResponseModel>> ListarFormaPagoAsync()
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new List<FORMA_PAGOS>();
            try
            {
                responseModel.Data = await _dataFormaPago.ListarFormaDePago(responseModel);
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
