using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface ISecurityUsuarios
    {
        Task<List<Usuarios>> ListarUsuarios(string activo = "S");
        //Listar todos los usuarios existentes
        Task<List<Usuarios>> ListarUsuarios(ResponseModel responseModel);

        //Validar el modelo si es valido el usuario
        bool ModeloUsuarioEsValido(ViewModelSecurity model, ResponseModel responseModel);

        //Guardar los datos usuario
        Task InsertOrUpdateUsuario(ViewModelSecurity model, ResponseModel responseModel);
        //Obtener el usuario para la editación
        Task<ViewModelSecurity> ObtenerUsuarioPorIdAsync(string usuarioID, ResponseModel responseModel);

        //obtener el nombre para filtrar el nombreusuario
        List<Usuarios> ObtenerUsuarioPorNombre(string value, ResponseModel responseModel);
        //Verificar la existencia del usuario en BD
        bool ExisteDataOnTablaUsuario(string usuarioID, ResponseModel responseModel);

        Task<string> EliminarUsuario(string usuarioID, ResponseModel responseModel);
    }
}
