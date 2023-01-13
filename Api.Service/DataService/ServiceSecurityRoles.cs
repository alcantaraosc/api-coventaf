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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class ServiceSecurityRoles: ISecurityRoles
    {
        private readonly CoreDBContext _db;

        public ServiceSecurityRoles(CoreDBContext db)
        {
            this._db = db;
        }

        /// <summary>
        /// listar todos los roles que existan en la base de datos.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Roles>> ListarRolesAsync()
        {
            var ListaRoles = new List<Roles>();

            try
            {                
                //Lista los usuarios en orden ascendentes por nombres
                ListaRoles = await _db.Roles.OrderBy(rl => rl.NombreRol).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return ListaRoles;
        }


        /// <summary>
        /// Listar todos los roles que esten activos
        /// </summary>
        /// <param name="activo"></param>
        /// <returns></returns>
        public async Task<List<Roles>> ListarRolesAsync(bool activo, ResponseModel responseModel)
        {
            var listaRoles = new List<Roles>();
            try
            {
                //Lista los usuarios en orden ascendentes por nombres
                listaRoles = await _db.Roles.Where(rl => rl.Activo == activo).OrderBy(rl => rl.NombreRol).ToListAsync();

                if (listaRoles == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Consulta invalida";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta valida";
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return listaRoles;
        }


        /// <summary>
        /// validar los campos de tabla ROLES
        /// </summary>
        /// <param name="rol"></param>
        /// <param name="responseModel"></param>
        /// <param name="rolId"></param>
        /// <returns></returns>

        public bool ModeloRolesEsValido(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int rolId = 0)
        {
            bool modeloIsValido = false;

            try
            {
                //validar 
                if (dataFuncionesRoles.Roles.NombreRol == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar el Nombre del Rol";
                    responseModel.NombreInput = "NombreRol";
                }
                else if (dataFuncionesRoles.Roles.Descripcion == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "Debes de Ingresar la descripcion del Rol";
                    responseModel.NombreInput = "Descripcion";
                }

                else
                {
                    //quitar los espacio al inicio y al fin y convertir en mayuscula
                    dataFuncionesRoles.Roles.NombreRol = dataFuncionesRoles.Roles.NombreRol.Trim().ToUpper();
                    dataFuncionesRoles.Roles.Descripcion = dataFuncionesRoles.Roles.Descripcion.Trim().ToUpper();

                    //comprobar si es nuevo Rol
                    if (rolId == 0)
                    {
                        //comprobar si el modelo es valido cuando se esta agregando un nuevo registro
                        modeloIsValido = ModelIsValidWhenIsNewRol(dataFuncionesRoles.Roles, responseModel);
                    }
                    else
                    //de lo contrario editar
                    {
                        //comprobar si el modelo es valido cuando se está editando el registro
                        modeloIsValido = ModelIsValidWhenIsEditRol(dataFuncionesRoles.Roles, responseModel);
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
        /// VALIDAR SI EN NUEVO ROL
        /// </summary>
        /// <param name="rol"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private bool ModelIsValidWhenIsNewRol(Roles rol, ResponseModel responseModel)
        {
            bool modeloIsValido = false;

            try
            {

                //comprobar si el existe el nombre del Rol
                if (ExisteRolPorNombre(rol.NombreRol.Trim()))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El nombre del rol ya existe";
                    responseModel.NombreInput = "NombreRol";
                }
                //comprobar si tiene check al campo activo
                else if (!rol.Activo)
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
        /// validar si existe el nombre del Rol
        /// </summary>
        /// <param name="nombreRol"></param>
        /// <returns></returns>
        public bool ExisteRolPorNombre(string nombreRol)
        {
            bool existeRegistro;

            try
            {

                existeRegistro = _db.Roles.Where(s => s.NombreRol.Trim() == nombreRol).Count() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                existeRegistro = false;
                throw new Exception("Error: " + ex.Message);
            }

            return existeRegistro;
        }

        /// <summary>
        /// Validar para EDITAR ROL
        /// </summary>
        /// <param name="rol"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        private bool ModelIsValidWhenIsEditRol(Roles rol, ResponseModel responseModel)
        {
            bool modeloIsValido = false;

            try
            {
                //Obtener el nombre del Rol por el id en la base de datos 
                var nombreRol = ObtenerSoloNombreRolPorId(rol.RolID);

                //comprobar si el nombre del rol que edito es diferente al nombre del rol de la base de datos y si existe el nombre del rol
                if ((nombreRol.Trim().ToUpper() != rol.NombreRol.Trim().ToUpper()) && (ExisteRolPorNombre(rol.NombreRol.Trim().ToUpper())))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "El nombre del Rol ya existe";
                    responseModel.NombreInput = "NombreRol";
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
        /// ESTE METODO ES PARA PODER FILTRAR X NOMBRE DEL ROL EN EL LISTADO
        /// </summary>
        /// <param name="nombrerol"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public List<Roles> ObtenerRolPorNombre(string value, ResponseModel responseModel)
        {
            var model = new List<Roles>();

            try
            {
                string[] filtro = { "NombreRol", "Descripcion" };
                bool encontrasteValor = false;
                for (var index = 0; index < 2 && !encontrasteValor; index++)
                {
                    switch (filtro[index])
                    {
                        case "NombreRol":
                            model = _db.Roles.Where(rol => rol.NombreRol.Contains(value)).ToList();
                            if (model.Count > 0) encontrasteValor = true;
                            break;

                        case "Descripcion":
                            model = _db.Roles.Where(rol => rol.Descripcion.Contains(value)).ToList();
                            if (model.Count > 0) encontrasteValor = true;
                            break;
                    }
                }




                if (model.Count == 0)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el rol en base de datos";

                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "<< Rol encontrados >>";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return model;
        }

        /// <summary>
        /// Obtenere el nombre del rol por ID
        /// </summary>
        /// <param name="rolID"></param>
        /// <returns></returns>
        public string ObtenerSoloNombreRolPorId(int rolID)
        {
            string NombreRol;
            try
            {

                NombreRol = (from nomrol in _db.Roles
                             where nomrol.RolID == rolID
                             select nomrol.NombreRol).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NombreRol;
        }

        /// <summary>
        /// Insertar o actualizar los datos de la tabla Roles
        /// </summary>
        /// <param name="rol"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public int InsertOrUpdateRoles(ViewModelSecurity dataFuncionesRoles, ResponseModel responseModel, int rolID = 0)
        {
            int result = 0;

            string ConvertirArrayString = new Utilidades().ConvertirEnCadenatring(dataFuncionesRoles.FuncionesRoles, "FuncionesRoles", "FuncionID");
            try
            {
                using (SqlConnection cn = new SqlConnection(ADONET.strConnect))
                {
                    using (SqlCommand cmd = new SqlCommand(@"SP_InsertOrUpdateRoles", cn))
                    {
                        //Aquí agregas los parámetros de tu procedimiento
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@RolID", dataFuncionesRoles.Roles.RolID);
                        cmd.Parameters.AddWithValue("@NombreRol", dataFuncionesRoles.Roles.NombreRol);
                        cmd.Parameters.AddWithValue("@Descripcion", dataFuncionesRoles.Roles.Descripcion);
                        cmd.Parameters.AddWithValue("@Activo", dataFuncionesRoles.Roles.Activo);
                        cmd.Parameters.AddWithValue("@ARRAY", ConvertirArrayString);

                        //Abres la conexión 
                        cn.Open();
                        //Ejecutas el procedimiento, y guardas en una variable tipo int el número de lineas afectadas en las tablas que se insertaron
                        //(ExecuteNonQuery devuelve un valor entero, en éste caso, devolverá el número de filas afectadas después del insert, si es mayor a > 0, entonces el insert se hizo con éxito)
                        result = cmd.ExecuteNonQuery();

                        if (result > 0)
                        {
                            responseModel.Mensaje = (rolID == 0) ? "Los datos se ha guardado correctamente" : "Se ha actualizado correctamente";
                            responseModel.Exito = 1;
                        }
                        else
                        {
                            responseModel.Mensaje = (rolID == 0) ? "No se pueden guardar los datos" : "No se puede actualizar los datos";
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

        /// <summary>
        /// Obtener el ID PARA PODER MODIFICAR EL REGISTO TABLA ROLES
        /// </summary>
        /// <param name="rolID"></param>
        /// <returns></returns>
        public async Task<ViewModelSecurity> ObtenerRolPorIdAsync(int rolID, ResponseModel responseModel)
        {

            //crea una instancia llamada func del objeto  roles
            Roles rol = new Roles(); //crea una instancia de Roles llamada rol el objeto es Roles
            rol.FuncionesRoles = new List<FuncionesRoles>();


            ViewModelSecurity ListFuncionesRoles = new ViewModelSecurity();
            ListFuncionesRoles.Roles = new Roles();
            ListFuncionesRoles.FuncionesRoles = new List<FuncionesRoles>();

            try
            {

                rol = await _db.Roles.Include(rl => rl.FuncionesRoles).Where(rl => rl.RolID == rolID).FirstOrDefaultAsync();

                //verificar que tenga registro la consulta
                if (rol != null)
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "Consulta exitosa";
                    //asignar valores a la instancia func
                    //ListFuncionesRoles.Roles = rol;
                    ListFuncionesRoles.Roles.RolID = rol.RolID;
                    ListFuncionesRoles.Roles.NombreRol = rol.NombreRol;
                    ListFuncionesRoles.Roles.Descripcion = rol.Descripcion;
                    ListFuncionesRoles.Roles.Activo = rol.Activo;
                    ListFuncionesRoles.Roles.FechaCreacion = rol.FechaCreacion;
                    ListFuncionesRoles.Roles.FechaModificacion = rol.FechaModificacion;

                    foreach (var item in rol.FuncionesRoles)
                    {
                        ListFuncionesRoles.FuncionesRoles.Add(new FuncionesRoles
                        {
                            FuncionID = item.FuncionID,
                            //llamar al metodo ObtenerSoloNombreFuncionPorId para obtener solo el nombre de la funcion
                            NombreFuncion = new ServiceSecurityFunciones(_db).ObtenerSoloNombreFuncionPorId(item.FuncionID),
                            RolID = item.RolID,
                            FechaCreacion = item.FechaCreacion,
                            FechaModificacion = item.FechaModificacion
                        }); 
                    }

                }
                else
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe los datos del rol en base de datos";
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
        /// ELIMINAR EL ROL 
        /// </summary>
        /// <param name="rolid"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<int> EliminarRoles(int rolID, ResponseModel responseModel)
        {
            var result = 0;
            try
            {
                //verificar si existe el rol en la base de datos
                if (!ExisteDataOnTablaRoles(rolID, responseModel))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el rol en la base de datos";
                }
                //verificar si existe el rol  en otras  tablas
                else if (ExisterolEnTablaRolesUsuarios(rolID, responseModel) || ExisteRolIDenTablaFuncionesRoles(rolID, responseModel))
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No se puede eliminar la rol, " +
                                            "esta siendo usada en otras tablas";
                }
                else
                {
                    //obtener los datos de la tabla roles
                    var roles = await ObtenerRolPorId(rolID, responseModel);
                    //elimina los datos de la tabla roles
                    _db.Roles.Remove(roles);
                    result = _db.SaveChanges();
                    //comprobar si elimino el rol
                    if (result > 0)
                    {
                        responseModel.Mensaje = "Se ha eliminado exitosamente";
                        responseModel.Exito = 1;
                    }
                    else
                    {
                        responseModel.Mensaje = "No se ha eliminado la sucursal";
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
        /// Buscar en la tabla rol si existe 
        /// </summary>
        /// <param name="rolid"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ExisteDataOnTablaRoles(int rolID, ResponseModel responseModel)
        {
            bool existeRegistro;

            try
            {
                //comprobar si en el la tabla rol existe registro 
                existeRegistro = _db.Roles.Where(id => id.RolID == rolID).Count() > 0 ? true : false;
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
        /// verificar el rol si existe en la taba ROLESUSUARIOS
        /// </summary>
        /// <param name="rolid"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ExisterolEnTablaRolesUsuarios(int rolID, ResponseModel responseModel)
        {
            bool existeRegistro;

            try
            {
                //comprobar si en el la tabla ROLES existe id del rol 
                existeRegistro = _db.RolesUsuarios.Where(id => id.RolID == rolID).Count() > 0 ? true : false;
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
        /// este metodo se utiliza para Verificar el rolId si existe en las tablas FUNCIONESROLES 
        /// </summary>
        /// <param name="rolID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public bool ExisteRolIDenTablaFuncionesRoles(int rolID, ResponseModel responseModel)
        {
            bool existeRegistro;

            try
            {
                //verificar si existe la funcion en la tabla funcionesroles 
                existeRegistro = _db.FuncionesRoles.Where(fr => fr.RolID == rolID).Count() > 0 ? true : false;
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
        /// Obtener el rol por ID 
        /// </summary>
        /// <param name="rolID"></param>
        /// <param name="responseModel"></param>
        /// <returns></returns>
        public async Task<Roles> ObtenerRolPorId(int rolID, ResponseModel responseModel)
        {
            var model = new Roles();

            try
            {
                model = await _db.Roles.Where(ec => ec.RolID == rolID).FirstOrDefaultAsync();

                //verificar si el modelo es null
                if (model == null)
                {
                    responseModel.Exito = 0;
                    responseModel.Mensaje = "No existe el rol en la base de datos";
                }
                else
                {
                    responseModel.Exito = 1;
                    responseModel.Mensaje = "<<Rol encontrado>>";
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