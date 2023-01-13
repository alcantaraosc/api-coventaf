using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface ISecurityRoles
    {
        //Listar todos los roles
        Task<List<Roles>> ListarRolesAsync();
        //Listar todos los roles que esten activos
        Task<List<Roles>> ListarRolesAsync(bool activo, ResponseModel responseModel);
        bool ModeloRolesEsValido(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int rolID = 0);
        int InsertOrUpdateRoles(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int rolID = 0);
        Task<ViewModelSecurity> ObtenerRolPorIdAsync(int rolID, ResponseModel responseModel);
        Task<int> EliminarRoles(int rolID, ResponseModel responseModel);
        List<Roles> ObtenerRolPorNombre(string value, ResponseModel responseModel);
    }
}
