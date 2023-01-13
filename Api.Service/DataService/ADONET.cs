using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Service.DataService
{
    public class ADONET
    {
        public static string strConnect;

        public static DataTable Leer(string Cmd)
        {
            DataTable dt = new DataTable();
            SqlConnection Cn = GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(Cmd, Cn);
            try
            {
                Cn.Open();
                da.SelectCommand.Connection = Cn;
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                try
                {
                    var x = ex.Message;
                    da = new SqlDataAdapter(("SET DATEFORMAT DMY; EXEC " + Cmd), Cn);
                    da.SelectCommand.Connection = Cn;
                    da.Fill(dt);
                }
                catch (Exception exa)
                {
                    throw new Exception(exa.Message);
                }
            }
            return dt;
        }


        public static SqlConnection GetConnection()
        {
            try
            {

                return new SqlConnection(strConnect);
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }



        //public List<EstadoCivil> ListarEstadoCivil()
        //{
        //	var estadoCivil = new List<EstadoCivil>();
        //	try
        //	{
        //		using (var Cn = ContextConexion.GetConnection())
        //		{
        //			//abrir la conexion
        //			Cn.Open();
        //			SqlDataReader dr = null;
        //			SqlCommand Cmd = new SqlCommand(" SELECT idCivil, Nombre FROM EstadoCivil", Cn);
        //			//indicar que es un procedimiento almacenado
        //			Cmd.CommandType = CommandType.Text;
        //			Cmd.CommandTimeout = 0;
        //			dr = Cmd.ExecuteReader();
        //			while (dr.Read())
        //			{
        //				estadoCivil.Add(new EstadoCivil
        //				{
        //					idCivil = dr["idCivil"].ToString(),
        //					Nombre = dr["Nombre"].ToString(),
        //				});

        //			}


        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		throw new Exception(ex.Message);
        //	}
        //	return estadoCivil;
        //}


        //public int InsertOrUpdateEstadoCivil(EstadoCivilDAL estadoCivil)
        //{
        //	int result = 0;
        //	try
        //	{
        //		using (var Cn = ADONET.GetConnection())
        //		{
        //			string SentenciaSql;
        //			if (estadoCivil.IdEstadoCivil == 0)
        //			{
        //				SentenciaSql = @"INSERT INTO EstadoCivilCliente (Descripcion, Habilitado) VALUES (@Descripcion, @Habilitado)";
        //			}
        //			else
        //			{
        //				SentenciaSql = @"UPDATE EstadoCivilCliente SET Descripcion=@Descripcion, Habilitado=@Habilitado WHERE (IdEstadoCivil=@IdEstadoCivil)";
        //			}

        //			SqlCommand Cmd = new SqlCommand(SentenciaSql, Cn);
        //			Cmd.CommandType = CommandType.Text;
        //			Cmd.CommandTimeout = 0;

        //			Cmd.Parameters.AddWithValue("@Descripcion", estadoCivil.Descripcion);
        //			Cmd.Parameters.AddWithValue("@Habilitado", estadoCivil.Habilitado);
        //			//si estas editando entonces agregar el parametro
        //			if (estadoCivil.IdEstadoCivil > 0) Cmd.Parameters.AddWithValue("@IdEstadoCivil", estadoCivil.IdEstadoCivil);
        //			//abrir la conexion
        //			Cn.Open();
        //			result = Cmd.ExecuteNonQuery();
        //		}
        //	}
        //	catch (Exception ex)
        //	{
        //		throw new Exception(ex.Message);
        //	}
        //	return result;
        //}


        ////eliminar del catalogo el estado civil
        public int crearUnaTabla()
        {
            var result = 0;
            try
            {
                using (var Cn = ADONET.GetConnection())
                {
                    //SqlCommand Cmd = new SqlCommand("CREATE TABLE [Cliente2](  [ClienteID][varchar](30) NOT NULL,     [UserIDCreacion][int] NOT NULL,    [FechaCreacion][datetime] NOT NULL   ))", Cn);
                    //Cmd.CommandType = CommandType.Text;
                    //Cmd.CommandTimeout = 0;                    
                    ////abrir la conexion
                    //Cn.Open();
                    //result = Cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}