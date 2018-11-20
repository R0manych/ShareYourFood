using DataContext.Repositories.Interfaces;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        public DataSet GetNewRows(string sqlQuery, params object[] parametres)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataContextModel"].ConnectionString;
            var dataSet = new DataSet();
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                var command = new OracleCommand(sqlQuery, conn);
                foreach (var param in parametres)
                {
                    command.Parameters.Add(param);
                }
                var adapter = new OracleDataAdapter(command);
                adapter.Fill(dataSet);
            }
            return dataSet;
        }

        public void ExecuteCommand(string sqlQuery, params object[] parametres)
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataContextModel"].ConnectionString;
            using (var conn = new OracleConnection(connectionString))
            {
                conn.Open();
                var command = new OracleCommand(sqlQuery, conn);
                foreach (var param in parametres)
                {
                    command.Parameters.Add(param);
                }
                command.ExecuteNonQuery();
            }
        }

        public bool FindAny(string sqlQuery, params object[] parametres) => GetNewRows(sqlQuery, parametres).Tables[0].Rows.Count > 0;        
    }
}
