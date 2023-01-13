using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class DataFormaPago: IFormaPago
    {
        private readonly CoreDBContext _db;

        public DataFormaPago(CoreDBContext db)
        {
            this._db = db;
        }

        public async Task<IList<FORMA_PAGOS>> ListarFormaDePago(ResponseModel responseModel)
        {
            var listaFormaPago = new List<FORMA_PAGOS>();
            try
            {
                listaFormaPago = await _db.FORMA_PAGOS.Where(fp=>fp.Activo =="S").ToListAsync();
                if (listaFormaPago.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "consulta no encontrada";
                }                        
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaFormaPago;
        }
    }
}
