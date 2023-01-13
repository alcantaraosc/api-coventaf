using Api.Model.Modelos;
using Api.Model.View;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface IArticulo
    {
        public Task<ViewArticulo> ObtenerArticuloPorIdAsync(ResponseModel responseModel, string codigoBarra, string bodegaID);
    }
}
