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
    [Route("api/securityfunciones")]
    [Authorize] //aquí estaríamos agregando a nivel de todos los métodos del controlador
    public class SecurityFuncionesController : Controller
    {
        private readonly ISecurityFunciones _dataSecurityFuncion;



        public SecurityFuncionesController(ISecurityFunciones iSecurityFuncion)
        {
            this._dataSecurityFuncion = iSecurityFuncion;
        }

        private ResponseModel respuestModel()
        {
            //1-exito 0-si exito
            return new ResponseModel() { Exito = 1 };
        }


        [HttpGet("ListarFuncionesAsync")]
        public async Task<ActionResult<IEnumerable<Funciones>>> ListarFuncionesAsync()
        {
            var ListrFunciones = new List<Funciones>();
            var responseModel = respuestModel();

            try
            {
                ListrFunciones = await _dataSecurityFuncion.ListarFuncionesAsync();
                return ListrFunciones;
            }

            catch (Exception ex)
            {
                responseModel.Exito = 0;
                responseModel.Mensaje = ex.Message;
                return NotFound(responseModel);
            }
        }

        [HttpGet("ListarFuncionesAsync/{activo}")]
        public async Task<ActionResult<ResponseModel>> ListarFuncionesAsync(bool activo)
        {

            var responseModel = respuestModel();
            responseModel.Data = new List<Funciones>();

            try
            {
                responseModel.Data = await _dataSecurityFuncion.ListarFuncionesAsync(responseModel, activo);
            }

            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

        //ESTE METODO ES PARA PODER FILTRAR X NOMBRE_FUNCIONES EN EL  LISTADO
        [HttpGet("ObtenerFuncionesPorNombre/{nombfuncion}")]
        public ActionResult<ResponseModel> ObtenerFuncionesPorNombre(string nombfuncion)
        {
            var responseModel = respuestModel();
            responseModel.Data = new List<Funciones>();

            try
            {
                //obtener la consulta por Id de la funcion
                responseModel.Data = _dataSecurityFuncion.ObtenerFuncionesPorNombre(nombfuncion, responseModel);

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }

        [HttpPost("GuardarFuncionesAsync")]
        public ActionResult<ResponseModel> GuardarFuncionesAsync(ViewModelSecurity dataFuncionesRoles)
        {
            var responseModel = respuestModel();
            int result = 0;
            try
            {
                //validar que el modelo este correcto antes de guardar en la base de datos
                if (_dataSecurityFuncion.ModeloFuncionesEsValido(dataFuncionesRoles, responseModel))
                {
                    result = _dataSecurityFuncion.InsertOrUpdateFunciones(dataFuncionesRoles, responseModel);
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }
            return responseModel;

        }

        //ActualizarFuncionesAsync
        [HttpPut("ActualizarFuncionesAsync/{funcionID}")]
        public ActionResult<ResponseModel> ActualizarFuncionesAsync(int funcionID, ViewModelSecurity dataFuncionesRoles)
        {
            var responseModel = respuestModel();
            int result = 0;

            try
            {
                //validar que el modelo este correcto antes de guardar cambios en la base de datos
                if (_dataSecurityFuncion.ModeloFuncionesEsValido(dataFuncionesRoles, responseModel, funcionID))
                {
                    result = _dataSecurityFuncion.InsertOrUpdateFunciones(dataFuncionesRoles, responseModel, funcionID);
                }

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return responseModel;
        }


        [HttpGet("ObtenerFuncionesPorIdAsync/{funcionID}")]
        public async Task<ActionResult<ResponseModel>> ObtenerFuncionesPorIdAsync(int funcionID)
        {
            var responseModel = respuestModel();
            responseModel.Data = new ViewModelSecurity();

            //obtener la consulta por funcionID
            try
            {
                //obtener la consulta por funcionID
                responseModel.Data = await _dataSecurityFuncion.ObtenerFuncionesPorIdAsync(funcionID, responseModel);
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
            }

            return Ok(responseModel);

        }

        // DELETE: api/security/funcionID
        [HttpDelete("EliminarFuncionesAsync/{funcionID}")]
        public async Task<ActionResult<ResponseModel>> EliminarFuncionesAsync(int funcionID)
        {
            var responseModel = respuestModel();
            try
            {
                await _dataSecurityFuncion.EliminarFunciones(funcionID, responseModel);
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

