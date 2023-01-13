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
    [Route("api/securityusuario")]
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador
    public class SecurityUsuarioController : ControllerBase
    {
        private readonly ISecurityUsuarios _serviceSecurityUsuario;
       
        public SecurityUsuarioController(ISecurityUsuarios serviceSecurityUsuario)
        {
            this._serviceSecurityUsuario = serviceSecurityUsuario;
        }

        private ResponseModel respuestModel()
        {
            //1-exito 0-si exito
            return new ResponseModel() { Exito = 0 };
        }

        // GET: Security
        [HttpGet("ListarUsuariosAsync")]
        public async Task<ActionResult<ResponseModel>> ListarUsuariosAsync()
        {           
            var responseModel = respuestModel();
            responseModel.Data = new List<Usuarios>();

            try
            {
                responseModel.Data = await _serviceSecurityUsuario.ListarUsuarios();                              
            }

            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;              
            }

            return responseModel;
          
        }

        [HttpPost("GuardarUsuarioAsync")]
        public async Task<ActionResult<ResponseModel>> GuardarUsuarioAsync(ViewModelSecurity model)
        {
            var responseModel = respuestModel();
           
            try
            {
                //validar que el modelo este correcto antes de guardar en la base de datos
                if (_serviceSecurityUsuario.ModeloUsuarioEsValido(model, responseModel))
                {
                    await _serviceSecurityUsuario.InsertOrUpdateUsuario(model, responseModel);
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
        [HttpGet("ObtenerUsuarioPorNombre/{nombrerUsuario}")]
        public async Task<ActionResult<ResponseModel>> ObtenerUsuarioPorNombre(string nombrerUsuario)
        {
            var responseModel = respuestModel();
            responseModel.Data = new List<Usuarios>();

            try
            {
                //obtener la consulta por Id del usuario
                responseModel.Data = _serviceSecurityUsuario.ObtenerUsuarioPorNombre(nombrerUsuario, responseModel);

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

        [HttpGet("ObtenerUsuarioPorIdAsync/{usuarioID}")]
        public async Task<ActionResult<ResponseModel>> ObtenerUsuarioPorIdAsync(string usuarioID)
        {
            var responseModel = respuestModel();
            responseModel.Data = new ViewModelSecurity();
      

            //obtener la consulta por Id del usuario
            try
            {
                //obtener la consulta por Id del tipo de usuario
                responseModel.Data = await _serviceSecurityUsuario.ObtenerUsuarioPorIdAsync(usuarioID, responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return Ok(responseModel);
        }

        [HttpPut("ActualizarUsuarioAsync/{usuarioID}")]
        public async Task<ActionResult<ResponseModel>> ActualizarUsuarioAsync(string usuarioID, [FromBody] ViewModelSecurity model)
        {
            var responseModel = respuestModel();
            
            try
            {
                if (_serviceSecurityUsuario.ExisteDataOnTablaUsuario(usuarioID, responseModel))
                {
                    //validar que el modelo este correcto antes de guardar en la base de datos
                    if (_serviceSecurityUsuario.ModeloUsuarioEsValido(model, responseModel))
                    {
                        await _serviceSecurityUsuario.InsertOrUpdateUsuario(model, responseModel);
                    }
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
        [HttpDelete("EliminarUsuarioAsync/{usuarioID}")]
        public async Task<ActionResult<ResponseModel>> EliminarUsuarioAsync(string usuarioID)
        {
            var responseModel = respuestModel();

            try
            {
                await _serviceSecurityUsuario.EliminarUsuario(usuarioID, responseModel);
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

