using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OracleClient;

namespace PruebaOracle
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
                    string query = "addpersona";

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] collection = new OracleParameter[4];
                        collection[0] = new OracleParameter("IdPersona", OracleType.Int32);
                        collection[0].Value = persona.IdPersona;

                        collection[1] = new OracleParameter("Nombre", OracleType.NVarChar);
                        collection[1].Value = persona.Nombre;

                        collection[2] = new OracleParameter("ApellidoPaterno", OracleType.NVarChar);
                        collection[2].Value = persona.ApellidoPaterno;

                        collection[3] = new OracleParameter("ApellidoMaterno", OracleType.NVarChar);
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
        public static ML.Result Update(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (OracleConnection contex = new OracleConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "updatepersona";

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] collection = new OracleParameter[4];
                        collection[0] = new OracleParameter("IdPersona", OracleType.Int32);
                        collection[0].Value = persona.IdPersona;

                        collection[1] = new OracleParameter("Nombre", OracleType.NVarChar);
                        collection[1].Value = persona.Nombre;

                        collection[2] = new OracleParameter("ApellidoPaterno", OracleType.NVarChar);
                        collection[2].Value = persona.ApellidoPaterno;

                        collection[3] = new OracleParameter("ApellidoMaterno", OracleType.NVarChar);
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

        public static ML.Result Delete(ML.Persona persona)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (OracleConnection contex = new OracleConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "deletepersona";

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = contex;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] collection = new OracleParameter[1];
                        collection[0] = new OracleParameter("p_IdPersona", OracleType.Int32);
                        collection[0].Value = persona.IdPersona;

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

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OracleConnection context = new OracleConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SELECT IdPersona, Nombre, ApellidoPaterno, ApellidoMaterno FROM Persona";

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        //cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tablePersona = new DataTable();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);

                        da.Fill(tablePersona);

                        if (tablePersona.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow row in tablePersona.Rows)
                            {
                                ML.Persona persona = new ML.Persona();
                                persona.IdPersona = int.Parse(row[0].ToString());
                                persona.Nombre = row[1].ToString();
                                persona.ApellidoPaterno = row[2].ToString();
                                persona.ApellidoMaterno = row[3].ToString();
                               
                                result.Objects.Add(persona);
                            }

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Producto";
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

        public static ML.Result GetById(int IdPersona)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (OracleConnection context = new OracleConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SELECT IdPersona, Nombre, ApellidoPaterno, ApellidoMaterno FROM Persona WHERE IdPersona=@IdPersona";

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        OracleParameter[] collection = new OracleParameter[1];

                        collection[0] = new OracleParameter("IdPersona", SqlDbType.Int);
                        collection[0].Value = IdPersona;

                        cmd.Parameters.AddRange(collection);

                        DataTable tablePersona = new DataTable();

                        OracleDataAdapter da = new OracleDataAdapter(cmd);

                        da.Fill(tablePersona);

                        if (tablePersona.Rows.Count > 0)
                        {
                            DataRow row = tablePersona.Rows[0];
                            result.Objects = new List<object>();

                            
                                ML.Persona persona = new ML.Persona();
                                persona.IdPersona = int.Parse(row[0].ToString());
                                persona.Nombre = row[1].ToString();
                                persona.ApellidoPaterno = row[2].ToString();
                                persona.ApellidoMaterno = row[3].ToString();

                                result.Objects.Add(persona);
                           

                            result.Correct = true;

                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Producto";
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
