using Api.Model.View;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.COVENTAF.Controllers.PuntoDeVenta
{
    [Route("api/articulos")]
    [ApiController]  
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador]
    public class ArticulosController : ControllerBase
    {

        private readonly IArticulo _dataArticulo;

        //aplicando inyeccion 
        public ArticulosController(IArticulo dataArticulo)
        {
            this._dataArticulo = dataArticulo;
        }


        [HttpGet("ObtenerArticuloPorIdAsync/{codigoBarra}/{bodegaID}")]
        public async Task<ActionResult<ResponseModel>> ObtenerArticuloPorIdAsync(string codigoBarra, string bodegaID)
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new ViewArticulo();
            try
            {
                //llamar al metodo ObtenerArticuloPorIdAsync para obtener el registro del articulo
                responseModel.Data = await _dataArticulo.ObtenerArticuloPorIdAsync( responseModel, codigoBarra, bodegaID);
            }
            catch (Exception ex)
            {
                //-1 significa que existe un error
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }




        // GET: api/<ArticulosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ArticulosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticulosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticulosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticulosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
