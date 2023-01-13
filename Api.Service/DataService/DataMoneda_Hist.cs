using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class DataMoneda_Hist: IMoneda_Hist
    {
        private readonly CoreDBContext _db;
        
        public DataMoneda_Hist(CoreDBContext db)
        {
            this._db = db;
        }
   
        /// <summary>
        /// obtener el tipo de cambio del dia
        /// </summary>
        /// <returns></returns>
        public async Task<MONEDA_HIST> ObtenerTipoCambioDelDiaAsync(ResponseModel responseModel)
        {
            //clase para obtener el tipo de cambio del dia
            var tipoCambio = new MONEDA_HIST();
            try
            {
                tipoCambio = await _db.MONEDA_HIST.Where(tc => tc.Fecha == DateTime.Now.Date).FirstOrDefaultAsync();
                //si el objeto tipoCambio no tiene registro
                if(tipoCambio != null)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El Tipo de cambio del dia no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return tipoCambio;
        }
    }
}
