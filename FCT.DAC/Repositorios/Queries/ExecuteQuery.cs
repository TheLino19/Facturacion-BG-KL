using FCT.DAC.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Repositorios.Queries
{
    public static class ExecuteQuery
    {
        //DbConexion.FCT_BG;

        public static async Task<T> ExecuteAsync<T>( List<SqlParameter> sqlParameters,string storedProcedure)
        {
            using var connection = new SqlConnection(DbConexion.FCT_BG);
            using var command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (sqlParameters != null)
                command.Parameters.AddRange(sqlParameters.ToArray()!);

            await connection.OpenAsync();

            object result = await command.ExecuteScalarAsync();

            if (result == null || result == DBNull.Value)
                return default!;

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static async Task<List<Dictionary<string, object>>> ExecuteRawAsync(List<SqlParameter> parameters, string storedProcedure)
        {
            var result = new List<Dictionary<string, object>>();

            using var connection = new SqlConnection(DbConexion.FCT_BG);
            using var command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
                command.Parameters.AddRange(parameters.ToArray()!);

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var row = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[reader.GetName(i)] = reader.IsDBNull(i) ? null! : reader.GetValue(i);
                }

                result.Add(row);
            }

            return result;
        }

        public static async Task<int> ExecuteNonQueryAsync(List<SqlParameter> parameters,string storedProcedure)
        {
            using var connection = new SqlConnection(DbConexion.FCT_BG);
            using var command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
                command.Parameters.AddRange(parameters.ToArray());

            await connection.OpenAsync();

            int affectedRows = await command.ExecuteNonQueryAsync();
            return affectedRows;
        }
    }
}
