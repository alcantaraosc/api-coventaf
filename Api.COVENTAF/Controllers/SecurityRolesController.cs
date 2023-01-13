using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Api.COVENTAF.Controllers
{
    [ApiController]
    [Route("api/securityroles")]
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador
    public class SecurityRolesController : Controller
    {
        private readonly ISecurityRoles _serviceSecurityRol;

        public SecurityRolesController(ISecurityRoles iSecurityRoles)
        {
            this._serviceSecurityRol = iSecurityRoles;
        }

        private ResponseModel respuestModel()
        {
            //1-exito 0-si exito
            return new ResponseModel() { Exito = 1 };
        }


        [HttpGet("ListarRolesAsync")]
        public async Task<ActionResult<IEnumerable<Roles>>> ListarRolesAsync()
        {
            var ListrRoles = new List<Roles>();
            var responseModel = new ResponseModel(); respuestModel();

            try
            {
                ListrRoles = await _serviceSecurityRol.ListarRolesAsync();
                return ListrRoles;
            }
            catch (Exception ex)
            {
                responseModel.Exito = 0;
                responseModel.Mensaje = ex.Message;
                return NotFound(responseModel);
            }
        }

        [HttpGet("ListarRolesAsync/{activo}")]
        public async Task<ActionResult<ResponseModel>> ListarRolesAsync(bool activo)
        {

            var responseModel = respuestModel();
            responseModel.Data = new List<Roles>();

            try
            {
                responseModel.Data = await _serviceSecurityRol.ListarRolesAsync(activo, responseModel);
            }

            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

        //continue 10 11 2021 
        [HttpPost("GuardarRolesAsync")]
        public ActionResult<ResponseModel> GuardarRolesAsync(ViewModelSecurity dataFuncionesRoles)
        {

            var responseModel = respuestModel();
            int result = 0;

            try
            {
                //validar que el modelo este correcto antes de guardar en la base de datos
                if (_serviceSecurityRol.ModeloRolesEsValido(dataFuncionesRoles, responseModel))
                {
                    result = _serviceSecurityRol.InsertOrUpdateRoles(dataFuncionesRoles, responseModel);
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;

        }

        //ESTE METODO ES PARA PODER FILTRAR X NOMBRE DEL ROL EN EL LISTADO
        [HttpGet("ObtenerRolPorNombre/{nombreRol}")]
        public ActionResult<ResponseModel> ObtenerRolPorNombre(string nombreRol)
        {
            var responseModel = respuestModel();
            responseModel.Data = new List<Roles>();

            try
            {
                //obtener la consulta por Id del ROL
                responseModel.Data = _serviceSecurityRol.ObtenerRolPorNombre(nombreRol, responseModel);

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

        [HttpGet("ObtenerRolPorIdAsync/{rolID}")]
        public async Task<ActionResult<ResponseModel>> ObtenerRolPorIdAsync(int rolID)
        {

            ResponseModel responseModel = respuestModel();
            responseModel.Data = new ViewModelSecurity();

            try
            {
                //obtener la consulta del ObtenerRolPorIdAsync
                responseModel.Data = await _serviceSecurityRol.ObtenerRolPorIdAsync(rolID, responseModel);

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            //var userJson = JsonSerializer.Serialize(user, options);

            return Ok(responseModel);

        }


        [HttpPut("ActualizarRolesAsync/{rolID}")]
        public ActionResult<ResponseModel> ActualizarRolesAsync(int rolID, ViewModelSecurity dataFuncionesRoles)
        {
            var responseModel = respuestModel();
            int result = 0;

            try
            {
                //validar que el modelo este correcto antes de guardar en la base de datos
                if (_serviceSecurityRol.ModeloRolesEsValido(dataFuncionesRoles, responseModel, rolID))
                {
                    result = _serviceSecurityRol.InsertOrUpdateRoles(dataFuncionesRoles, responseModel, rolID);
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

        // DELETE: api/security/5
        [HttpDelete("EliminarRolesAsync/{rolID}")]
        public async Task<ActionResult<ResponseModel>> EliminarRolesAsync(int rolID)
        {
            var responseModel = respuestModel();
            try
            {
                await _serviceSecurityRol.EliminarRoles(rolID, responseModel);
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
