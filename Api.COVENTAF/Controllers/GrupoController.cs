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
    [Route("api/grupo")]
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador
    public class GrupoController : ControllerBase
    {

        private readonly IGrupo _serviceGrupo;
        

        public GrupoController(IGrupo serviceGrupo)
        {
            this._serviceGrupo = serviceGrupo;
        }


        [HttpGet("ListarGruposAsync")]
        public async Task<ActionResult<ResponseModel>> ListarGruposAsync()
        {

            var responseModel = new ResponseModel() { Exito = 0 };
            responseModel.Data = new List<Grupos>();

            try
            {
                responseModel.Data = await _serviceGrupo.ListarGruposAsync(responseModel);
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
