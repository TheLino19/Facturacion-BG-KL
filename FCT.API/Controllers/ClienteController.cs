using FCT.BE.Commons.Dtos.Req.Cliente;
using FCT.BE.Commons.Dtos.Resp.cliente;
using FCT.BE.Commons.Dtos.Resp.Usuario;
using FCT.BE.Commons.Helpers;
using FCT.BE.Model.Respuesta;
using FCT.BL.Services.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace FCT.API.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(
            IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpPost("CrearCliente")]
        public async Task<ResponseModel<string>> CrearCliente([FromBody] DtoClienteIns dtoCliente)
        {
            return await _clienteServices.CrearCliente(dtoCliente);
        }

        [HttpPost("EditarCliente")]
        public async Task<ResponseModel<string>> EditarCliente([FromBody] DtoClienteEdit dtoClienteEdit)
        {
            return await _clienteServices.EditarCliente(dtoClienteEdit);
        }

        [HttpPost("ObtenerCliente")]
        public async Task<ResponseModel<DtoClienteResp>> ObtenerCliente(int Id)
        {
            return await _clienteServices.ObtenerCliente(Id);
        }

        [HttpPost("ObtenerClientes")]
        public async Task<ResponseModel<List<DtoClienteResp>>> ObtenerClientes(FiltrosUsuario filtrosUsuario)
        {
            return await _clienteServices.ObtenerClientes(filtrosUsuario);
        }
        [HttpPost("EliminarCliente")]
        public async Task<ResponseModel<int>> EliminarCliente(int Id)
        {
            return await _clienteServices.EliminarClientes(Id);
        }
    }
}
