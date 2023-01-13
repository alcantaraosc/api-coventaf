using Api.Context;
using Api.Helpers;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Api.Service.DataService
{
    public class AuthService : IAuthService
    {
        private readonly CoreDBContext _db;
        public AuthService(CoreDBContext db)
        {
            this._db = db;
        }

        public bool ValidateLogin(string username, string password, ResponseModel responseModel)
        {
            bool existeUsuario = true;

            //encryptar la constraseña
            var passwordCifrado =  new EncryptMD5().EncriptarMD5(password);
                                  
            Usuarios User = new Usuarios();
            try
            {
                //consultar el usuario
                User = _db.Usuarios.Where(user => user.Usuario == username && user.ClaveCifrada == passwordCifrado).FirstOrDefault();

                //comprobar si el usau
                if (User == null)
                {
                    //cambiar el estado
                    existeUsuario = false;
                    responseModel.SetFocus = true;
                    //hacer una consulta para comprobar si el usuario existe
                    User = _db.Usuarios.Where(u => u.Usuario == username).FirstOrDefault();
                    if (User == null)
                    {
                        responseModel.Mensaje = "El usuario no existe en la base de datos";
                        responseModel.NombreInput = "usuario";
                    }
                    else
                    {
                        responseModel.Mensaje = "El Password es incorrecto!";
                        responseModel.NombreInput = "password";
                    }
                }
                else
                {
                    List<string> roleSsistema = new List<string>();
                  
                    var roles = new List<RolesUsuarios>();
                    roles = _db.RolesUsuarios.Where(ruser => ruser.UsuarioID == username).ToList();
                    int index = 0;
                    foreach(var item in  roles)
                    {
                        //asignar el nombre del rol
                        string nombreRol= new ServiceSecurityRoles(_db).ObtenerSoloNombreRolPorId(item.RolID);
                        roleSsistema.Add(nombreRol);
                        //incrementar
                        index = index + 1;
                    }

                    responseModel.DataAux = roleSsistema;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return existeUsuario;         
        }

        public string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez)
        {
            var fechaExpiracion = fechaActual.Add(tiempoValidez);
            //Configuramos las claims
            var claims = new Claim[]
            {
            new Claim(JwtRegisteredClaimNames.Sub,username),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat,
                new DateTimeOffset(fechaActual).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                ClaimValueTypes.Integer64
            ),
            new Claim("roles","Cliente"),
            new Claim("roles","Administrador"),
            };

            //Añadimos las credenciales
            var signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("G3VF4C6KFV43JH6GKCDFGJH45V36JHGV3H4C6F3GJC63HG45GH6V345GHHJ4623FJL3HCVMO1P23PZ07W8")),
                    SecurityAlgorithms.HmacSha256Signature
            );//luego se debe configurar para obtener estos valores, así como el issuer y audience desde el appsetings.json

            //Configuracion del jwt token
            var jwt = new JwtSecurityToken(
                issuer: "Peticionario",
                audience: "Public",
                claims: claims,
                notBefore: fechaActual,
                expires: fechaExpiracion,
                signingCredentials: signingCredentials
            );

            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
    }
}