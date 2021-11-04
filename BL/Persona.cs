using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

namespace BL
{
    public class Persona
    {
        public static ML.Result Add(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (OracleConnection contex = new OracleConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "ADDPERSONA";

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] collection = new OracleParameter[4];
                        collection[0] = new OracleParameter("IdPersona", SqlDbType.Int);
                        collection[0].Value = persona.IdPersona;

                        collection[1] = new OracleParameter("Nombre", SqlDbType.NVarChar);
                        collection[1].Value = persona.Nombre;

                        collection[2] = new OracleParameter("ApellidoPaterno", SqlDbType.NVarChar);
                        collection[2].Value = persona.ApellidoPaterno;

                        collection[3] = new OracleParameter("ApellidoMaterno", SqlDbType.NVarChar);
                        collection[3].Value = persona.ApellidoMaterno;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrio un error";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
