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

namespace Api.COVENTAF.Controllers
{
    [ApiController]
    [Route("api/bodegas")]
    [Authorize] //aquí estaríamos agregando a nivel 
    public class BodegasController : Controller
    {
        private readonly IBodega _dataBodega;

        //aplicando inyeccion 
        public BodegasController(IBodega dataBodega)
        {
            this._dataBodega = dataBodega;
        }

        [HttpGet("ListarBodegasAsync")]
        public async Task<ActionResult<ResponseModel>> ListarBodegasAsync()
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new List<BODEGA>();
            try
            {
                //obtener la lista de bodegas que estan activas
                responseModel.Data = await _dataBodega.ListarBodegasAsync(responseModel);
            }
            catch (Exception ex)
            {
                //-1 indica que existe algun error del servidor
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }



        // POST: BodegasController/Create
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
    }
}
