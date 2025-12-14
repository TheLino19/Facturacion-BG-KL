using FCT.BE.Commons.Dtos.Req.Producto;
using FCT.BE.Commons.Dtos.Resp.Producto;
using FCT.DAC.Helpers.Mapper;
using FCT.DAC.Helpers.Utils;
using FCT.DAC.Repositorios.Queries;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FCT.DAC.Repositorios.Producto
{
    public class ProductoRepository : IProductoRepository
    {
        public async Task<string> CrearProducto(DtoProductoIns dtoProductoIns)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.Codigo, dtoProductoIns.Codigo),
                new SqlParameter(Parameters.Nombre, dtoProductoIns.Nombre),
                new SqlParameter(Parameters.PrecioUnitario, dtoProductoIns.PrecioUnitario),
            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_InsertarProducto);
            return rows == 0 ? string.Empty : dtoProductoIns.Nombre;
        }

        public async Task<string> EditarProducto(DtoProductoEdit dtoProductoEdit)
        {
            List<SqlParameter> parameters = new()
            {
                new SqlParameter(Parameters.Id, dtoProductoEdit.Id),
                new SqlParameter(Parameters.Nombre, dtoProductoEdit.Nombre),
                new SqlParameter(Parameters.Codigo, dtoProductoEdit.Codigo),
                new SqlParameter(Parameters.PrecioUnitario, dtoProductoEdit.PrecioUnitario),

            };
            int rows = await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EditarProducto);
            return rows == 0 ? string.Empty : dtoProductoEdit.Nombre;
        }

        public async Task<int> EliminarProductos(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.Id, Id) };
            return await ExecuteQuery.ExecuteNonQueryAsync(parameters, StoredProcedure.SP_EliminarProducto);
        }

        public async Task<DtoProductoResp> ObtenerProducto(int Id)
        {
            List<SqlParameter> parameters = new() { new SqlParameter(Parameters.Id, Id) };
            DataTable sqlDataReader = await ExecuteQuery.ExecuteRawAsync(parameters, StoredProcedure.SP_ObtenerProductoId);
            return ProductoMapperSql.MapearOnlyProd(sqlDataReader);
        }

        public async Task<List<DtoProductoResp>> ObtenerProductos()
        {          
            DataTable sqlDataReader = await ExecuteQuery.ExecuteRawAsync(null, StoredProcedure.SP_ObtenerProductos);
            return ProductoMapperSql.MapearProd(sqlDataReader);
        }
    }
}
