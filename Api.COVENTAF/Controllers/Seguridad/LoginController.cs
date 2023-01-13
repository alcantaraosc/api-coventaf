using Api.Model.Modelos;
using Api.Model.Request;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.COVENTAF.Controllers.Seguridad
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private readonly IAuthService authService;

        public LoginController(IAuthService authService)
        {
            this.authService = authService;
        }


        //public ActionResult Token(UserLogin credenciales)
        [HttpPost("Authenticate")]
        public ActionResult<ResponseModel> Authenticate([FromBody] AuthRequest crendenciales)
        {   
            ResponseModel responseModel = new ResponseModel();
            //responseModel.data= new usu
            try
            {
                //validar las credenciales del usuarios.                                
                if (authService.ValidateLogin(crendenciales.Usuario, crendenciales.Password, responseModel))
                {
                    //obtener la fecha
                    var fechaActual = DateTime.Now;
                    //tiempo valido para el token
                    var validez = TimeSpan.FromHours(5);
                    
                    //fecha de expiracion del token
                    //fecha de expiracion del token
                    var fechaExpiracion = fechaActual.Add(validez);

                    //obtener el token del JWT
                    var token = authService.GenerateToken(fechaActual, crendenciales.Usuario, validez);
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "usuario logeado exitosamente";


                    responseModel.Data = new
                    {
                        usuario = crendenciales.Usuario,
                        token = token,
                        expireAt = fechaExpiracion,
                    };
                    
                                             
                }
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                responseModel.Data = null;
            }

     
            return responseModel;




            //if (something == null)
            //{
            //    return new HttpNotFoundResult(); // 404
            //}
            //else
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.OK); // 200
            //};

            // return StatusCode(401);
        }
    }
}
