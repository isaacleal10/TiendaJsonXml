using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using TiendaJsonXml.Models;

namespace TiendaJsonXml.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        [HttpPost]
        [Route("enviar-pedido")]
        public IActionResult EnviarPedido([FromBody] PedidoJSON pedidoJson)
        {
            //Transformar JSON a XML
            var pedidoXml = TransformarJSONaXML(pedidoJson);
            //Simular la llamada al sistema externo (SOAP)
            var respuestaXml = EnviarSOAP(pedidoXml);
            //Transformar respuesta XML a JSON
            var respuestaJson = TransformarXMLaJSON(respuestaXml);
            return Ok(respuestaJson);
        }
        private string TransformarJSONaXML(PedidoJSON pedidoJson)
        {
            var pedidoSoap = new PedidoSOAP
            {
                Pedido = pedidoJson.NumPedido,
                Cantidad = pedidoJson.CantidadPedido,
                EAN = pedidoJson.CodigoEAN,
                Producto = pedidoJson.NombreProducto,
                Cedula = pedidoJson.NumDocumento,
                Direccion = pedidoJson.Direccion
            };
            var serializer = new XmlSerializer(typeof(PedidoSOAP));
            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, pedidoSoap);
            return stringWriter.ToString();
        }
        private string EnviarSOAP(string pedidoXml)
        {
            //Simulación de una respuesta SOAP
            return @"<Respuesta>
            <Codigo>80375472</Codigo>
            <Mensaje>Entrega exitosamente al cliente</Mensaje>
            </Respuesta>";
        }
        private RespuestaJSON TransformarXMLaJSON(string respuestaXml)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(respuestaXml);
            var codigo = xmlDoc.SelectSingleNode("//Codigo")?.InnerText;
            var mensaje = xmlDoc.SelectSingleNode("//Mensaje")?.InnerText;
            return new RespuestaJSON
            {
                CodigoEnvio = codigo,
                Estado = mensaje
            };
        }
    }
}
