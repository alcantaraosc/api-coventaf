using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface ICliente
    {
        public Task<CLIENTES> ObtenerClientePorIdAsync(string clienteID, ResponseModel responseModel);
       /* public Task<Cliente> ObtenerClientesPorIdAsync(string clienteID, ResponseModel responseModel);
        public List<DropDownList> ListarFiltroDeCliente(string value = "ClienteID");*/
    }
}
