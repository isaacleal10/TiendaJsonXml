using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class PedidoService : IPedidoService
    {
        public string ConvertirJsonAXml(PedidoDTO pedido)
        {
            var xmlSerializer = new XmlSerializer(typeof(PedidoDTO));
            using var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, pedido);
            return stringWriter.ToString();
        }

        public RespuestaDTO ConvertirXmlAJson(string xmlResponse)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlResponse);
            return new RespuestaDTO
            {
                CodigoEnvio = xmlDoc.SelectSingleNode("//Codigo")?.InnerText,
                Estado = xmlDoc.SelectSingleNode("//Mensaje")?.InnerText
            };
        }
    }
}
