using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Microsoft.Data.SqlClient;

namespace DAL.ORM
{
    public static class Dapper
    {

        public static string ConnectionString =
            "Server =.; Database=HospitalManagementSystem;Trusted_Connection=True;MultipleActiveResultSets=true";


        public static void ExceptionWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new SqlConnection(connectionString: ConnectionString);
            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }

            sqlCon.Execute(procedureName, param: param, commandType: CommandType.StoredProcedure);
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new SqlConnection(connectionString: ConnectionString);
            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }

            return (T) Convert.ChangeType(
                sqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using var sqlCon = new SqlConnection(connectionString: ConnectionString);
            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }

            return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
        }
    }
}
