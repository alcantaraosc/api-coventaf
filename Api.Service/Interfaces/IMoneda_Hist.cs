using Api.Model.Modelos;
using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface IMoneda_Hist
    {
        public Task<MONEDA_HIST> ObtenerTipoCambioDelDiaAsync(ResponseModel responseModel);
    }
}
