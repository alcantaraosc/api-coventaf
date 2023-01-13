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
    public class ServiceSecurityFunciones: ISecurityFunciones
    {

        private readonly CoreDBContext _db;


        public ServiceSecurityFunciones(CoreDBContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// Listar la tabla funciones
        /// </summary>
        /// <returns></returns>
        public async Task<List<Funciones>> ListarFuncionesAsync()
        {
            var ListaFunciones = new List<Funciones>();

            try
            {
                //Lista de funciones  en orden ascendentes por nombres
                ListaFunciones = await _db.Funciones.OrderBy(nomb => nomb.NombreFuncion).ToListAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return ListaFunciones;
        }


        /// <summary>
        /// Listar las funciones con el parametro activo
        /// </summary>
        /// <param name="activo"></param>
        /// <returns></returns>
        public async Task<List<Funciones>> ListarFuncionesAsync(ResponseModel responseModel, bool activo = true)
        {
            var listaFunciones = new List<Funciones>();

            try
            {
                //Lista de funciones  en orden NombreFuncion
                listaFunciones = await _db.Funciones.Where(a => a.Activo == activo).OrderBy(nomb => nomb.NombreFuncion).ToListAsync();
                if (listaFunciones.Count > 0)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta Exitosa";
                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe registro";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return listaFunciones;
        }


        /// <summary>
        /// ESTO ES PARA PODER FILTRAR X NOMBRE_FUNCION
        /// </summary>
        /// <param name="value"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public List<Funciones> ObtenerFuncionesPorNombre(string value, ResponseModel responseModel)
        {
            var model = new List<Funciones>();

            try
            {
                string[] filtro = { "NombreFuncion", "Codigo", "Descripcion" };
                bool encontrasteValor = false;
                for (var index = 0; index < 3 && !encontrasteValor; index++)
                {
                    switch (filtro[index])
                    {
                        case "NombreFuncion":
                            model = _db.Funciones.Where(fun => fun.NombreFuncion.Contains(value)).ToList();
                            if (model.Count > 0) encontrasteValor = true;
                            break;

                        case "Codigo":
                            model = _db.Funciones.Where(fun => fun.Codigo.Contains(value)).ToList();
                            if (model.Count > 0) encontrasteValor = true;
                            break;

                        case "Descripcion":
                            model = _db.Funciones.Where(fun => fun.Descripcion.Contains(value)).ToList();
                            if (model.Count > 0) encontrasteValor = true;
                            break;
                    }
                }


                if (model.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el nombre de la funcion en base de datos";

                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "<< funciones encontradas >>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return model;
        }

        /// <summary>
        /// validar los campos de la tabla funciones
        /// </summary>
        /// <param name="dataFuncionesRoles"></param>
        /// <param name="responseModel"></param>
        /// <param name="funcionID"></param>
        /// <returns></returns>
        public bool ModeloFuncionesEsValido(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int funcionID = 0)
        {
            bool modeloIsValido = false;

            try
            {
                //validar 
                if (dataFuncionesRoles.Funciones.NombreFuncion == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar el Nombre de la función";
                    responseModel.NombreInput = "NombreFuncion";
                }
                else if (dataFuncionesRoles.Funciones.Codigo == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar el código de la función";
                    responseModel.NombreInput = "Codigo";

                }
                else if (dataFuncionesRoles.Funciones.Descripcion == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar la descripcion de la función";
                    responseModel.NombreInput = "Descripcion";
                }

                else
                {

                    //quitar los espacio al inicio y al fin y convertir en mayuscula
                    dataFuncionesRoles.Funciones.NombreFuncion = dataFuncionesRoles.Funciones.NombreFuncion.Trim().ToUpper();
                    dataFuncionesRoles.Funciones.Codigo = dataFuncionesRoles.Funciones.Codigo.Trim().ToUpper();
                    dataFuncionesRoles.Funciones.Descripcion = dataFuncionesRoles.Funciones.Descripcion.Trim().ToUpper();

                    //comprobar si es nuevo Rol
                    if (funcionID == 0)
                    {
                        //comprobar si el modelo es valido cuando se esta agregando un nuevo registro
                        modeloIsValido = ModelIsValidWhenIsNewFuncion(dataFuncionesRoles, responseModel);
                    }
                    //de lo contrario estas editando 
                    else
                    {
                        //comprobar si el modelo es valido cuando se está editando el registro
                        modeloIsValido = ModelIsValidWhenIsEditFuncion(dataFuncionesRoles, responseModel);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return modeloIsValido;
        }

        /// <summary>
        /// valida si el modelo es valido 
        /// </summary>
        /// <param name="dataFuncionesRoles"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private bool ModelIsValidWhenIsNewFuncion(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel)
        {
            bool modeloIsValido = false;

            try
            {

                //comprobar si el existe el nombre del Rol
                if (ExisteFuncionPorNombre(dataFuncionesRoles.Funciones.NombreFuncion.Trim()))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El nombre de la funcion ya existe";
                    responseModel.NombreInput = "NombreFuncion";
                }
                else if (ExisteCodFunciones(dataFuncionesRoles.Funciones.Codigo))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El código ya existe, escribe otro diferente";
                    responseModel.NombreInput = "Codigo";

                }
                //comprobar si tiene check al campo activo
                else if (!dataFuncionesRoles.Funciones.Activo)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de activar el campo activo";
                    responseModel.NombreInput = "Activo";
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

        /// <summary>
        /// validar si existe el nombre de la funcion en la tabla
        /// </summary>
        /// <param name="nombreFuncion"></param>
        /// <returns></returns>
        public bool ExisteFuncionPorNombre(string nombreFuncion)
        {
            bool existeRegistro;

            try
            {
                existeRegistro = _db.Funciones.Where(s => s.NombreFuncion == nombreFuncion).Count() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }

            return existeRegistro;
        }


        /// <summary>
        /// validar si existe el codigo de la función 
        /// </summary>
        /// <param name="Codigo"></param>
        /// <returns></returns>
        public bool ExisteCodFunciones(string Codigo)
        {
            bool existcodfuncion;

            try
            {
                existcodfuncion = _db.Funciones.Where(cd => cd.Codigo == Codigo).Count() > 0 ? true : false;

            }
            catch (Exception ex)
            {

                throw new Exception("Error: " + ex.Message);
            }

            return existcodfuncion;

        }

        /// <summary>
        /// obtener el codigo de la funciones
        /// </summary>
        /// <param name="funcionID"></param>
        /// <returns></returns>
        public string ObtenerSoloCodigoFuncionesPorId(int? funcionID)
        {
            string codigoFunciones;
            try
            {
                //obtener el codigofunciones
                codigoFunciones = (from s in _db.Funciones
                                   where s.FuncionID == funcionID
                                   select s.Codigo).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return codigoFunciones;
        }

        /// <summary>
        /// Validar el modelo si es valido Para editar la tabla funciones
        /// </summary>
        /// <param name="listaFuncionesRoles"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private bool ModelIsValidWhenIsEditFuncion(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel)
        {
            bool modeloIsValido = false;

            try
            {
                //Obtener el nombrefunciones por el id en la base de datos 
                var nombreFuncion = ObtenerSoloNombreFuncionPorId(dataFuncionesRoles.Funciones.FuncionID);
                //Obtener el codigofunciones por el id en la base de datos 
                var codigoFuncionesBD = ObtenerSoloCodigoFuncionesPorId(dataFuncionesRoles.Funciones.FuncionID);

                //comprobar si el nombre del usuario que edito es diferente al nombre del usuario de la base de datos y si existe el nombre del usuario
                if ((nombreFuncion.Trim().ToUpper() != dataFuncionesRoles.Funciones.NombreFuncion.Trim().ToUpper()) && (ExisteFuncionPorNombre(dataFuncionesRoles.Funciones.NombreFuncion.Trim().ToUpper())))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El nombre de la función ya existe";
                    responseModel.NombreInput = "NombreFuncion";
                }
                else if ((codigoFuncionesBD.Trim().ToUpper() != dataFuncionesRoles.Funciones.Codigo.Trim().ToUpper()) && (ExisteCodFunciones(dataFuncionesRoles.Funciones.Codigo.Trim().ToUpper())))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El código de la función ya existe";
                    responseModel.NombreInput = "Codigo";
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

        /// <summary>
        /// Obtener el nombre de la Funcion 
        /// </summary>
        /// <param name="funcionID"></param>
        /// <returns></returns>
        public string ObtenerSoloNombreFuncionPorId(int funcionID)
        {
            string nombreFuncion;
            try
            {

                nombreFuncion = (from nomfuncion in _db.Funciones
                                 where nomfuncion.FuncionID == funcionID
                                 select nomfuncion.NombreFuncion).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return nombreFuncion;
        }

        /// <summary>
        /// Insertar el registro en la tabla funciones
        /// </summary>
        /// <param name="dataFuncionesRoles"></param>
        /// <param name="responseModel"></param>
        /// <param name="funcionID"></param>
        /// <returns></returns>
        public int InsertOrUpdateFunciones(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int funcionID = 0)
        {
            int result = 0;
            string ConvertirArrayString = new Utilidades().ConvertirEnCadenatring(dataFuncionesRoles.FuncionesRoles, "FuncionesRoles", "RolID");

            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SP_InsertOrUpdateFunciones", cn))
                    {
                        //Aquí agregas los parámetros de tu procedimiento
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@funcionID", dataFuncionesRoles.Funciones.FuncionID);
                        cmd.Parameters.AddWithValue("@NombreFuncion", dataFuncionesRoles.Funciones.NombreFuncion);
                        cmd.Parameters.AddWithValue("@Codigo", dataFuncionesRoles.Funciones.Codigo);
                        cmd.Parameters.AddWithValue("@Descripcion", dataFuncionesRoles.Funciones.Descripcion);
                        cmd.Parameters.AddWithValue("@Activo", dataFuncionesRoles.Funciones.Activo);
                        cmd.Parameters.AddWithValue("@ARRAY", ConvertirArrayString);

                        //Abres la conexión 
                        cn.Open();
                        //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron
                        //(ExecuteNonQuery devuelve un valor entero, en éste caso, devolverá el número de filas afectadas después del insert, si es mayor a > 0, entonces el insert se hizo con éxito)
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            responseModel.Mensaje = (funcionID == 0) ? "Los datos se ha guardado correctamente" : "Se ha actualizado correctamente";
                            responseModel.Exito = 1;
                        }
                        else
                        {
                            responseModel.Mensaje = (funcionID == 0) ? "No se pueden guardar los datos" : "No se puede actualizar los datos";
                            responseModel.Exito = 0;
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }


        //public int InsertOrUpdateFunciones(ListaFuncionesRoles dataFuncionesRoles, ResponseModel responseModel, int funcionID = 0)
        //{
        //using var transaction = _db.Database.BeginTransaction();



        ////comprobar si el funcionID es nuevo
        //if (funcionID == 0)
        //{
        //    //**************  insertar datos en la tabla funciones      **************************************/
        //    dataFuncionesRoles.Funciones.FechaCreacion = DateTime.Now;
        //    _db.Funciones.Add(dataFuncionesRoles.Funciones);                   
        //    result = _db.SaveChanges();

        //    /************** insertar una lista de registro en la tabla FuncionesRoles ****************************/                   
        //    var listFuncionesRoles = dataFuncionesRoles.FuncionesRoles.ConvertAll(x => new FuncionesRoles() 
        //    {
        //        funcionID = dataFuncionesRoles.Funciones.funcionID, 
        //        RolID = x.RolID, 
        //        FechaCreacion = DateTime.Now 
        //    });

        //    _db.FuncionesRoles.AddRange(listFuncionesRoles);
        //   _db.SaveChanges();

        //}
        //else
        //{
        //    /******************** actualizacion de las funciones *******************************/
        //    _db.Funciones.Attach(dataFuncionesRoles.Funciones);
        //    dataFuncionesRoles.Funciones.FechaModificacion = DateTime.Now;
        //    result=_db.SaveChanges();

        //    /*****************actualizacion de la tabla FuncionesRoles*/

        //    //context.Configuration.ValidateOnSaveEnabled = false;
        //    var valueFuncionesRoles = new List<FuncionesRoles>();
        //    foreach (var item in dataFuncionesRoles.FuncionesRoles)
        //    {
        //        valueFuncionesRoles = new List<FuncionesRoles>(){ new FuncionesRoles { funcionID = item.funcionID, RolID = item.RolID, FechaModificacion = item.FechaModificacion } };                                                
        //    }

        //    _db.FuncionesRoles.AttachRange(valueFuncionesRoles);
        //    _db.SaveChanges();



        //string sqlQuery = null;
        //var vistafCliente = new List<VistafichaClientes>();

        /*
      var funcionesRoles = dataFuncionesRoles.FuncionesRoles.ConvertAll(x => new FuncionesRoles() { funcionID = x.funcionID, RolID = x.RolID, FechaModificacion = DateTime.Now });
      _db.FuncionesRoles.AddRange(funcionesRoles);
      _db.SaveChanges();
      */

        /*

        this._db.FuncionesRoles.Attach(dataFuncionesRoles.FuncionesRoles);

        this.Context.Persons.Attach(person)
DbEntityEntry<Person> entry = Context.Entry(person);
        entry.Property(e => e.Name).IsModified = true;
        Context.SaveChanges();
        */


        //guardar los cambio en transaccion
        //transaction.Commit();
        //result = 1;


        //if (result > 0)
        //{                                     
        //    responseModel.mensaje = (funcionID == 0) ? "Los datos se ha guardado correctamente" : "Se ha actualizado correctamente";
        //    responseModel.exito = 1;
        //}
        //else
        //{                    
        //    responseModel.mensaje = (funcionID == 0) ? "No se pueden guardar los datos" : "No se puede actualizar los datos";
        //    responseModel.exito = 0;
        //}
        //}
        //catch (Exception ex)
        //{
        //    //deshacer los cambios en la transaccion
        //    transaction.Rollback();                    
        //    throw new Exception(ex.Message);

        //}
        //}



        /// <summary>
        /// obtener funcionID para poder editar el registro
        /// </summary>
        /// <param name="funcionID"></param>
        /// <returns></returns>
        public async Task<ViewModelSecurity> ObtenerFuncionesPorIdAsync(int funcionID, ResponseModel responseModel)
        {
            //crea una instancia llamada func del objeto  Funciones
            Funciones func = new Funciones();
            func.FuncionesRoles = new List<FuncionesRoles>();

            ViewModelSecurity ListFuncionesRoles = new ViewModelSecurity();
            ListFuncionesRoles.Funciones = new Funciones();
            ListFuncionesRoles.FuncionesRoles = new List<FuncionesRoles>();


            try
            {

                func = await _db.Funciones.Include(fr => fr.FuncionesRoles).Where(f => f.FuncionID == funcionID).FirstOrDefaultAsync();

                //verificar que tenga registro la consulta
                if (func != null)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";

                    //asignar valores a la instancia func
                    ListFuncionesRoles.Funciones.FuncionID = func.FuncionID;
                    ListFuncionesRoles.Funciones.NombreFuncion = func.NombreFuncion;
                    ListFuncionesRoles.Funciones.Codigo = func.Codigo;
                    ListFuncionesRoles.Funciones.Descripcion = func.Descripcion;
                    ListFuncionesRoles.Funciones.Activo = func.Activo;
                    ListFuncionesRoles.Funciones.FechaCreacion = func.FechaCreacion;
                    ListFuncionesRoles.Funciones.FechaModificacion = func.FechaModificacion;

                    foreach (var item in func.FuncionesRoles)
                    {
                        ListFuncionesRoles.FuncionesRoles.Add(new FuncionesRoles
                        {
                            RolID = item.RolID,
                            //llamar al metodo ObtenerSoloNombreRolPorId para obtener solo el nombre del rol
                            NombreRol = new ServiceSecurityRoles(_db).ObtenerSoloNombreRolPorId(item.RolID),
                            FuncionID = item.FuncionID,
                            FechaCreacion = item.FechaCreacion,
                            FechaModificacion = item.FechaModificacion
                        });
                    }

                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe los datos de la funcion en base de datos";
                    responseModel.Data = null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return ListFuncionesRoles;
        }

        /// <summary>
        /// METODO PARA ELIMINAR EL REGISTRO FUNCIONES
        /// </summary>
        /// <param name="funcionID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<int> EliminarFunciones(int funcionID, ResponseModel responseModel)
        {
            var result = 0;
            try
            {

                //verificar si existe el funcion en la base de datos
                if (!ExisteDataOnTablaFunciones(funcionID, responseModel))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe la funcion en la base de datos";
                }
                //verificar si existe la funcion en otras  tabla
                else if (ExisteIdFuncionenTablaFuncionesRoles(funcionID, responseModel))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se puede eliminar la Funcion del usuario, " +
                                            "esta siendo usada en otras tablas";
                }
                else
                {
                    //obtener los datos de la tabla funcionesroles
                    var funciones = await ObtenerFuncionesPorId(funcionID, responseModel);
                    //elimina los datos de la tabla funciones
                    _db.Funciones.Remove(funciones);
                    result = _db.SaveChanges();
                    //comprobar si elimino la funcion
                    if (result > 0)
                    {
                        responseModel.Mensaje = "Se ha eliminado el registro exitosamente";
                        responseModel.Exito = 1;
                    }
                    else
                    {
                        responseModel.Mensaje = "No se ha eliminado la funciones seleccionada";
                        responseModel.Exito = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="funcID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ExisteIdFuncionenTablaFuncionesRoles(int funcID, ResponseModel responseModel)
        {
            bool existeFuncUs;

            try
            {
                //verificar si existe la funcion en la tabla funcionesroles 
                existeFuncUs = _db.FuncionesRoles.Where(id => id.FuncionID == funcID).Count() > 0 ? true : false;

            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception("Error: " + ex.Message);
            }
            return existeFuncUs;
        }



        /// <summary>
        /// verificar si existe el funcion en la tabla BD PARA PODER ELIMINAR 
        /// </summary>
        /// <param name="funcionID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ExisteDataOnTablaFunciones(int funcionID, ResponseModel responseModel)
        {
            bool existeRegistro;

            try
            {
                //comprobar si en el la tabla funciones existe registro 
                existeRegistro = _db.Funciones.Where(id => id.FuncionID == funcionID).Count() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                responseModel.Exito = -1;
                responseModel.Mensaje = ex.Message;
                throw new Exception("Error: " + ex.Message);
            }
            return existeRegistro;
        }


        /// <summary>
        /// obtener el funcionID EN LA TABLA PARA PODER ELIMINAR 
        /// </summary>
        /// <param name="funcionID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<Funciones> ObtenerFuncionesPorId(int funcionID, ResponseModel responseModel)
        {
            var model = new Funciones();

            try
            {
                model = await _db.Funciones.Where(ec => ec.FuncionID == funcionID).FirstOrDefaultAsync();

                //verificar si el modelo es null
                if (model == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe la funcion en la base de datos";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "<<funcion encontrada>>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return model;
        }
    }
}
