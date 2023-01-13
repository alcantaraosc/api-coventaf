using Api.Context;
using Api.Helpers;
using Api.Model.Modelos;
using Api.Model.ViewModels;
using Api.Service.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class FacturaService: IFactura
    {
        private readonly CoreDBContext _db;
        public FacturaService(CoreDBContext db)
        {
            this._db = db;
        }

        public async Task<List<Facturas>> ListarFacturasAsync(FiltroFactura filtroFactura, ResponseModel responseModel)
        {
            var listaFactura = new List<Facturas>();
            

            try
            {
                switch (filtroFactura.Tipofiltro)
                {
                    case "Factura del dia":
                        var fechaDeHoy = DateTime.Now.Date;
                       
                        listaFactura = await _db.Facturas.Where(x => x.Fecha.Date == fechaDeHoy.Date).ToListAsync();
                        //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                        break;

                    //case "Recuperar factura":
                    //    listaFactura = await _db.FacturaTemporal.Where(x => x.Factura == filtroFactura.Busqueda).ToListAsync();
                    //    //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                    //    break;

                    case "Rango de fecha":
                        listaFactura = await _db.Facturas.Where(x => x.Fecha >= filtroFactura.FechaInicio && x.Fecha <= filtroFactura.FechaFinal).ToListAsync();
                        //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                        break;

                }


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaFactura;
        }

        public async Task<List<FacturaTemporal>> ListarFacturaTemporalesAsync(FiltroFactura filtroFactura, ResponseModel responseModel)
        {
                    
            var listaFacturaTemp = new List<FacturaTemporal>();

            try
            {
                switch (filtroFactura.Tipofiltro)
                {
               

                    case "Factura Perdidas":
                        listaFacturaTemp = await _db.FacturaTemporal.Where(x => x.Factura == filtroFactura.Busqueda).ToListAsync();
                        //listaArticulo =await _db.ARTICULOS.FromSqlRaw("SELECT ARTICULO, DESCRIPCION From TIENDA.ARTICULO Where ARTICULO = {0}", consulta).FirstOrDefault();
                        break;
                }


            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaFacturaTemp;
        }

        //public async Task<FacturaTemporal> ObtenerFacturaTemporalesAsync(FiltroFactura filtroFactura, ResponseModel responseModel)
        //{

        //}


        //public async Task<int> InsertOrUpdateEstadoCivilAsync(ResponseModel responseModel, EstadoCivil model, int estadoCivilID = 0)
        public async Task<int> InsertOrUpdateCierreCaja(ResponseModel responseModel, CIERRE_CAJA model)
        {
            int result = 0;
            try
            {
                Guid guid = Guid.NewGuid();
                //string datGuid = guid.ToString();
                model.RowPointer = guid.ToString();
                //if (model.NUM_CIERRE_CAJA == "0")
                //{

                _db.CIERRE_CAJA.Add(model);
                //}
                //else
                //{
                //    //actualizacion
                //    _db.Update(model);
                //}
                result = await _db.SaveChangesAsync();

                if (result > 0)
                {
                    responseModel.Mensaje = (model.Num_Cierre_Caja == "0") ? "Los datos se ha guardado correctamente" : "Se ha actualizado correctamente";
                    responseModel.Exito = 1;
                }
                else
                {
                    responseModel.Mensaje = (model.Num_Cierre_Caja == "0") ? "No se pueden guardar los datos" : "No se puede actualizar los datos";
                    responseModel.Exito = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


        public async Task<string> ObtenerNoFactura(ResponseModel responseModel)
        {
            string result = "";
            try
            {             
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("USP_OBTENER_CONSECUT_FACTURA", cn);                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                 
                    var dr = await cmd.ExecuteReaderAsync();
                    if  (await dr.ReadAsync())
                    {
                        result = dr["CONSECUTIVO"].ToString();
                    }                    
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;     
        }

        public async Task<int> InsertOrUpdateFacturaTemporal(ResponseModel responseModel, FacturaTemporal model)
        {
            int result = 0;
            try
            {               
                model.Fecha = DateTime.Now.Date;
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("USP_INSERT_FACTURA_TEMP", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Factura", model.Factura);
                    cmd.Parameters.AddWithValue("@Fecha", model.Fecha);
                    cmd.Parameters.AddWithValue("@TipoCambio", model.TipoCambio);
                    cmd.Parameters.AddWithValue("@Bodega", model.Bodega);
                    cmd.Parameters.AddWithValue("@Consecutivo", model.Consecutivo);
                    cmd.Parameters.AddWithValue("@ArticuloID", model.ArticuloID);
                    cmd.Parameters.AddWithValue("@CodigoBarra", model.CodigoBarra);
                    cmd.Parameters.AddWithValue("@Cantidad", model.Cantidad);
                    cmd.Parameters.AddWithValue("@Descripcion", model.Descripcion);
                    cmd.Parameters.AddWithValue("@Unidad", model.Unidad);
                    cmd.Parameters.AddWithValue("@Precio", model.Precio);           
                    cmd.Parameters.AddWithValue("@Descuento", model.Descuento);                
                    result = await cmd.ExecuteNonQueryAsync();
                }
                            
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }

        private Facturas AsignarNuevosRegistro(ViewModelFacturacion model)
        {
            Facturas factura = new Facturas();
            var FacturaLinea = new List<FACTURA_LINEA>();
            factura = model.Factura;
            FacturaLinea = model.FacturaLinea;

            return factura;
        }

        /// <summary>
        /// guardar o actualizar los datos de la factura
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<int> InsertOrUpdateFactura(ViewModelFacturacion model, ResponseModel responseModel )
        {
            var utilidad = new Utilidades();
            Facturas facturas = new Facturas();
            //List<FACTURA_LINEA> facturaLinea = new List<FACTURA_LINEA>();
            facturas = model.Factura;
            //facturaLinea = model.FacturaLinea;
            
            int result = 0;
            //utilizar transacciones
            using var transaction = await _db.Database.BeginTransactionAsync();
            {
                try
                {
                    model.Factura.RowPointer = utilidad.GenerarGuid();
                    //agregar la factura
                    _db.Add<Facturas>(model.Factura);
                    //guardar los cambios en la tabla Factura
                    await _db.SaveChangesAsync();

                    for (int row = 0; row < model.FacturaLinea.Count; ++row)
                    {
                        var facturaLinea = new FACTURA_LINEA();
                        facturaLinea = model.FacturaLinea.ElementAt<FACTURA_LINEA>(row);
                        facturaLinea.RowPointer = utilidad.GenerarGuid();
                        _db.Add<FACTURA_LINEA>(facturaLinea);
                        await _db.SaveChangesAsync();                      
                    }

                    var listFactTemp = await _db.FacturaTemporal.Where(x => x.Factura == model.Factura.Factura).ToListAsync();

                    _db.FacturaTemporal.RemoveRange(listFactTemp);
                    await _db.SaveChangesAsync();
                    

                    await transaction.CommitAsync();
                    result = 1;                   
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }          
            }

            
            if (result > 0)
            {
                responseModel.Mensaje = "La factura se ha guardado exitosamente";
                responseModel.Exito = 1;
            }
            else
            {
                responseModel.Mensaje = "No se pudo guardar la informacion";
                responseModel.Exito = 0;
            }

            return result;
        }
        public async Task<int> EliminarFacturaTemporal(ResponseModel responseModel, string noFactura, string articulo)
        {
          
            int result = 0;
            try
            {
                
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    //Abrir la conección 
                    await cn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("USP_ELIMINAR_ITEM_TABLA_TEMP", cn);
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Factura", noFactura);
                    cmd.Parameters.AddWithValue("@ArticuloID", articulo);
                    
                    result = await cmd.ExecuteNonQueryAsync();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }
        public async Task<List<TIPO_TARJETAS>> ListarTipoTarjeta(ResponseModel responseModel)
        {
            var listaTipoTarjeta = new List<TIPO_TARJETAS>();
            
            try
            {
                listaTipoTarjeta = await _db.TIPO_TARJETA.ToListAsync();                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaTipoTarjeta;
        }

        /// <summary>
        /// Listar el catalogo de condicion de pagos
        /// </summary>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<List<CONDICION_PAGO>> ListarCondicionPago(ResponseModel responseModel)
        {
            var listaCondicionPago = new List<CONDICION_PAGO>();

            try
            {
                listaCondicionPago = await _db.CONDICION_PAGO.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return listaCondicionPago;
        }


        /// <summary>
        /// validar los campos de tabla factura
        /// </summary>
        /// <param name="model"></param>
        /// <param name="responseModel"></param>
        /// <param name="factura"></param>
        /// <returns></returns>

        
        public bool ModeloUsuarioEsValido(ViewModelFacturacion model, ResponseModel responseModel)
        {
            bool modeloIsValido = false;

            try
            {
               
                if (model.Factura.Factura  == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el numero de factura";
                    responseModel.NombreInput = "Factura";
                }
                else if (model.Factura.Cliente == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de ingresar el codigo del cliente";
                    responseModel.NombreInput = "Cliente";
                }
                else
                 {                    
                    modeloIsValido = true;
                 }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return modeloIsValido;
        }

        public Task<int> InsertOrUpdateFacturaTemporal(FacturaTemporal model, ResponseModel responseModel)
        {
            throw new NotImplementedException();
        }
    }
}
