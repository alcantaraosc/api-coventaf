using Api.Context;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Api.Service.DataService
{
    public class DataCliente: ICliente
    {
        private readonly CoreDBContext _db;
        public DataCliente( CoreDBContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// obtener el registro de un cliente por medio el codigo de cliente
        /// </summary>
        /// <param name="clienteID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<CLIENTES> ObtenerClientePorIdAsync(string clienteID, ResponseModel responseModel)
        {
            var cliente = new CLIENTES();
            try
            {
                cliente = await _db.CLIENTES.Where(cl => cl.Cliente == clienteID).FirstOrDefaultAsync();
                if (cliente != null)
                {
                    //1 signinfica que la consulta fue exitosa
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                }
                else
                {
                    //0 signinfica que la consulta no se encontro en la base de datos
                    responseModel.Exito = 0;
                    responseModel.Mensaje = $"El cliente {clienteID} no existe en la base de datos";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return cliente;
        }

    }
}
