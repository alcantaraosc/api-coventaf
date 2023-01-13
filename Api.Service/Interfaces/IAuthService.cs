using Api.Model.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.Interfaces
{
    public interface IAuthService
    {
        public bool ValidateLogin(string username, string password, ResponseModel responseModel);
        string GenerateToken(DateTime fechaActual, string username, TimeSpan tiempoValidez);
    }
}
