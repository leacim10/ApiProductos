using App.Entity.Settings;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DataAccess
{
    public interface IDataAccess
    {
        DataTable SelectStoredProcedure(string nameDB, string querySP, List<MySqlParameter> parameters);
        bool ExecuteStoredProcedure(string nameDB, string querySP, List<MySqlParameter> parameters);
    }
    public class DataAccess : IDataAccess
    {
        private dataBaseEntity _dataBase;

        public DataAccess(dataBaseEntity dataBase) 
        {
            _dataBase = dataBase;
        }

        public string connection(conecctionsDB conecctionsDB)
        {
            string connection = string.Empty;
            try
            {
                connection = $"Server={conecctionsDB.server};Port=3306;DataBase={conecctionsDB.dataBase};Uid={conecctionsDB.user};Pwd={conecctionsDB.password};";
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            return connection;
        }

        public bool ExecuteStoredProcedure(string nameDB, string querySP, List<MySqlParameter> parameters)
        {
            MySqlConnection conexion = new MySqlConnection(connection(_dataBase.conecctions.FirstOrDefault(x => x.name == nameDB)));
            try
            {
                MySqlCommand comando = new MySqlCommand(querySP, conexion);
                comando.CommandType = CommandType.StoredProcedure;

                if(parameters != null)
                {
                    foreach(var item in parameters)
                    {
                        if(item.Value == null)
                            item.Value = DBNull.Value;
                        comando.Parameters.Add(item);
                    }
                }

                conexion.Open();
                comando.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex) 
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
                MySqlConnection.ClearAllPools();
            }
        }

        public DataTable SelectStoredProcedure(string nameDB, string querySP, List<MySqlParameter> parameters)
        {
            DataTable consulta = new DataTable();
            MySqlConnection conexion = new MySqlConnection(connection(_dataBase.conecctions.FirstOrDefault(x => x.name == nameDB)));
            try
            {
                MySqlDataAdapter comando = new MySqlDataAdapter(querySP, conexion);
                comando.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        if (item.Value == null)
                            item.Value = DBNull.Value;
                        comando.SelectCommand.Parameters.Add(item);
                    }
                }

                conexion.Open();
                comando.Fill(consulta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
                MySqlConnection.ClearAllPools();
            }
            return consulta;
        }
    }
}
