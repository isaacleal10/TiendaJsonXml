using System.Xml.Serialization;

namespace TiendaJsonXml.Models
{
    public class PedidoJSON
    {
        public required string NumPedido { get; set; }
        public int CantidadPedido { get; set; }
        public required string CodigoEAN { get; set; }
        public required string NombreProducto { get; set; }
        public required string NumDocumento { get; set; }
        public required string Direccion { get; set; }
    }
    [XmlRoot("PedidoSOAP")]
    public class PedidoSOAP
    {
        public required string Pedido { get; set; }
        public int Cantidad { get; set; }
        public required string EAN { get; set; }
        public required string Producto { get; set; }
        public required string Cedula { get; set; }
        public required string Direccion { get; set; }
    }
    public class RespuestaJSON
    {
        public required string CodigoEnvio { get; set; }
        public required string Estado { get; set; }
    }
}
