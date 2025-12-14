using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BE.Commons.Dtos.Resp.cliente;
using FCT.BE.Commons.Helpers;

namespace FCT.DAC.Repositorios.Cliente
{
    public interface IClienteRepository
    {
        Task<string> CrearCliente(DtoClienteIns dtoClienteIns);
        Task<string> EditarCliente(DtoClienteEdit dtoClienteEdit);
        Task<DtoClienteResp> ObtenerCliente(int Id);
        Task<List<DtoClienteResp>> ObtenerClientes(FiltrosUsuario filtrosUsuario);
        Task<int> EliminarCliente(int Id);
    }
}
