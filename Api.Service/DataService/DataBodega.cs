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
    public class DataBodega: IBodega
    {
        private readonly CoreDBContext _db;
        public DataBodega(CoreDBContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Listar las bodegas activas
        /// </summary>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<List<BODEGA>> ListarBodegasAsync(ResponseModel responseModel)
        {
            var ListBodega = new List<BODEGA>();
            try
            {
                ListBodega = await _db.BODEGAS.Where(b=>b.Activo=="S").ToListAsync();
                if (ListBodega.Count >0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No hay registro de Bodega";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ListBodega;
        }
    }
}
