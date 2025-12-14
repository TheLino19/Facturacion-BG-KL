using FCT.DAC.Helpers;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FCT.DAC.Repositorios.Queries
{
    public static class ExecuteQuery
    {
        public static async Task<DataTable> ExecuteRawAsync(List<SqlParameter> parameters, string storedProcedure)
        {
            DataTable dt = new DataTable();
            using var connection = new SqlConnection(DbConexion.FCT_BG);
            using var command = new SqlCommand(storedProcedure, connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            if (parameters != null)
                command.Parameters.AddRange(parameters.ToArray());

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();
            // Crear las columnas
            for (int i = 0; i < reader.FieldCount; i++)
            {
                dt.Columns.Add(reader.GetName(i), reader.GetFieldType(i));
            }
            // Leer las filas
            while (await reader.ReadAsync())
            {
                var row = dt.NewRow();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = await reader.IsDBNullAsync(i) ? DBNull.Value : reader.GetValue(i);
                }
                dt.Rows.Add(row);
            }

            return dt;
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
