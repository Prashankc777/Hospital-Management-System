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
            using var SqlCon = new SqlConnection(connectionString: ConnectionString);
            if (SqlCon.State != ConnectionState.Open)
            {
                SqlCon.Open();
            }

            SqlCon.Execute(procedureName, param: param, commandType: CommandType.StoredProcedure);
        }

        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using var SqlCon = new SqlConnection(connectionString: ConnectionString);
            if (SqlCon.State != ConnectionState.Open)
            {
                SqlCon.Open();
            }

            return (T) Convert.ChangeType(
                SqlCon.ExecuteScalar(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));
        }

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using var SqlCon = new SqlConnection(connectionString: ConnectionString);
            if (SqlCon.State != ConnectionState.Open)
            {
                SqlCon.Open();
            }

            return SqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
        }
    }
}
