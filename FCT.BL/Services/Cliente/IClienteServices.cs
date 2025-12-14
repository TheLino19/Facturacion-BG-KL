using FCT.BE.Commons.Dtos.Req;
using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BE.Commons.Dtos.Resp.cliente;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCT.BL.Services.Cliente
{
    public interface IClienteServices
    {
        Task<ResponseModel<string>> CrearCliente(DtoClienteIns dtoClienteIns);
        Task<ResponseModel<string>> EditarCliente(DtoClienteEdit dtoClienteEdit);
        Task<ResponseModel<DtoClienteResp>> ObtenerCliente(int Id);
        Task<ResponseModel<List<DtoClienteResp>>> ObtenerClientes(FiltrosUsuario filtrosCliente);
        Task<ResponseModel<int>> EliminarClientes(int Id);
    }
}
