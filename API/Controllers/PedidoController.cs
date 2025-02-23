using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;
        private readonly IEnvioPedidoClient _envioPedidoClient;

        public PedidoController(IPedidoService pedidoService, IEnvioPedidoClient envioPedidoClient)
        {
            _pedidoService = pedidoService;
            _envioPedidoClient = envioPedidoClient;
        }

        [HttpPost("enviar-pedido")]
        public async Task<IActionResult> EnviarPedido([FromBody] PedidoDTO pedido)
        {
            var pedidoXml = _pedidoService.ConvertirJsonAXml(pedido);
            var responseXml = await _envioPedidoClient.EnviarPedidoAsync(pedidoXml);
            var responseJson = _pedidoService.ConvertirXmlAJson(responseXml);
            return Ok(responseJson);
        }
    }
}
