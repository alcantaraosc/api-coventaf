using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface IGrupo
    {
        Task<List<Grupos>> ListarGruposAsync(ResponseModel responseModel);
    }
}
