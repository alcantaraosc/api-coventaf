using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface ISecurityFunciones
    {
        Task<List<Funciones>> ListarFuncionesAsync();

        Task<List<Funciones>> ListarFuncionesAsync(ResponseModel responseModel, bool activo = true);

        List<Funciones> ObtenerFuncionesPorNombre(string value, ResponseModel responseModel);

        bool ModeloFuncionesEsValido(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int funcionID = 0);


        bool ExisteFuncionPorNombre(string nombreFuncion);

        bool ExisteCodFunciones(string Codigo);


        string ObtenerSoloCodigoFuncionesPorId(int? funcionID);


        string ObtenerSoloNombreFuncionPorId(int funcionID);

        int InsertOrUpdateFunciones(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int funcionID = 0);

        Task<ViewModelSecurity> ObtenerFuncionesPorIdAsync(int funcionID, ResponseModel responseModel);


        Task<int> EliminarFunciones(int funcionID, ResponseModel responseModel);


        bool ExisteIdFuncionenTablaFuncionesRoles(int funcID, ResponseModel responseModel);

        bool ExisteDataOnTablaFunciones(int funcionID, ResponseModel responseModel);

        Task<Funciones> ObtenerFuncionesPorId(int funcionID, ResponseModel responseModel);
    }
}
