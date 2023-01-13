using Api.Context;
using Api.Model.Modelos;
using Api.Model.View;
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
    public class DataArticulo: IArticulo
    {
        private readonly CoreDBContext _db;
        public DataArticulo(CoreDBContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// obtener el registro de un cliente por medio el codigo de cliente
        /// </summary>
        /// <param name="codigoBarra"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<ViewArticulo> ObtenerArticuloPorIdAsync( ResponseModel responseModel, string codigoBarra, string bodegaID)
        {
            var Articulo = new ViewArticulo ();
            try
            {
                Articulo = await _db.ViewArticulo.Where(art => art.CodigoBarra == codigoBarra && art.BodegaID == bodegaID).FirstOrDefaultAsync();
                //comprobar si el articulo no esta vacio.
                if (Articulo != null)
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El articulo {codigoBarra} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Articulo;
        }

    }
}
