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
    public class ServiceGrupo: IGrupo
    {
        private readonly CoreDBContext _db;

        public ServiceGrupo(CoreDBContext db)
        {
            this._db = db;
        }

     
        /// <summary>
        /// listar los grupos 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Grupos>> ListarGruposAsync(ResponseModel responseModel)
        {
            var listaGrupo = new List<Grupos>();
            try
            {
                listaGrupo = await _db.Grupo.ToListAsync();

                if (listaGrupo.Count >0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";                    
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se pudo hacer la consulta";
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaGrupo;

        }
    }
}
