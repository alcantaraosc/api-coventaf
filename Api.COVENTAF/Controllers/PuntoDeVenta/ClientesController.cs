using Api.Model.Modelos;
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
    

    [ApiController]
    [Route("api/clientes")]
    [Authorize] //aquí estaríamos agregando a nivel 
    public class ClientesController : ControllerBase
    {
        private readonly ICliente _dataCliente;

        //aplicando inyeccion 
        public ClientesController(ICliente dataCliente)
        {
            this._dataCliente = dataCliente;
        }


        [HttpGet("ObtenerClientePorIdAsync/{clienteID}")]     
        public async Task<ActionResult<ResponseModel>> ObtenerClientePorIdAsync(string clienteID)
        {
            var responseModel = new ResponseModel();
            responseModel.Data = new CLIENTES();
            try
            {
                //llamar al metodo ObtenerClientePorIdAsync para obtener el registro del cliente
                responseModel.Data = await _dataCliente.ObtenerClientePorIdAsync(clienteID, responseModel);
            }
            catch (Exception ex)
            {
                //-1 significa que existe un error
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

   

        // GET: api/<ClientesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClientesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
